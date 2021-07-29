using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBFunctions
{
    public class UserInfoManager
    {
        public static DataRow GetUserInfoByAccount(string _account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @"SELECT [ID],[Account],[PWD],[Name],[Email]
                     FROM UserInfo
                     WHERE [Account] = @account
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", _account));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return null;
            }
        }
    }
}
