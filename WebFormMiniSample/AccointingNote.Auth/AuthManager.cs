using DBFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AccointingNote.Auth
{
    public class AuthManager
    {
        /// <summary> Check is login or not </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }

        public static UserInfoModel GetCurrecntUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);
            //return dr;
            if(dr == null)
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            UserInfoModel model = new UserInfoModel();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Name = dr["Name"].ToString();
            model.Email = dr["Email"].ToString();

            return model;
        }

        /// <summary> 登出 </summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
        }

        /// <summary>
        /// 嘗試登入
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string pwd, out string errMsg)
        {
            // check empty
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd))
            {
                errMsg = "Account / Pwd is required.";
                return false;
            }

            var dr = UserInfoManager.GetUserInfoByAccount(account);

            if (dr == null)
            {
                errMsg = "Account doesn't exists.";
                return false;
            }

            // check account / password
            if (string.Compare(dr["Account"].ToString(), account, true) == 0 && string.Compare(dr["PWD"].ToString(), pwd, false) == 0)
            {
                HttpContext.Current.Session["UserLoginInfo"] = dr["Account"].ToString();
                errMsg = string.Empty;
                return true;
            }
            else
            {
                errMsg = "Login fail. Please check Account / PWD";
                return false;
            }
        }
    }
}
