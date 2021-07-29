using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBFunctions;

namespace AccountingNote
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check is already login or not
            if (this.Session["UserLoginInfo"] is null)
            {
                this.plcLogin.Visible = true;
            }
            else
            {
                this.plcLogin.Visible = true;
                Response.Redirect("/SystemAdmin/UserInfo.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Acc = this.txtAcc.Text;
            string inp_Pwd = this.txtPwd.Text;

            // check empty
            if(string.IsNullOrWhiteSpace(inp_Acc) || string.IsNullOrWhiteSpace(inp_Pwd))
            {
                this.ltlMsg.Text = "Account / Pwd is required.";
                return;
            }

            var dr = UserInfoManager.GetUserInfoByAccount(inp_Acc);

            if(dr == null)
            {
                this.ltlMsg.Text = "Account doesn't exists.";
                return;
            }

            // check account / password
            if (string.Compare(dr["Account"].ToString(), inp_Acc, true) == 0 && string.Compare(dr["PWD"].ToString(), inp_Pwd, false) == 0)
            {
                this.Session["UserLoginInfo"] = dr["Account"].ToString();
                Response.Redirect("/SystemAdmin/UserInfo.aspx");
            }
            else
            {
                this.ltlMsg.Text = "Login fail. Please check Account / PWD";
                return;
            }
        }
    }
}