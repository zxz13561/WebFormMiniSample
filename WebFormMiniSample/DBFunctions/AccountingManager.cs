using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBFunctions
{
    public class AccountingManager
    {
        /// <summary>
        /// 檢查流水帳清單
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataTable GetAccountingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT [ID],[Caption],[Amount],[ActType],[CreateDate]
                     FROM Accounting
                     WHERE UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return null;
            }
        }

        public static DataRow GetAccounting(int id, string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT 
                        [ID],
                        [Caption],
                        [Amount],
                        [ActType],
                        [CreateDate],
                        [Body]
                     FROM Accounting
                     WHERE ID = @id AND UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userID", userID));

            try
            {
                return DBHelper.ReadDataRow(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return null;
            }
        }

        /// <summary>
        /// 建立流水帳
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            // <<<check input>>>
            if(amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must be between 0 ~ 10,000,000");

            if(actType < 0 || actType > 1)
                throw new ArgumentException("Act Type must be 0 or 1");
            // <<< check input

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"INSERT INTO [dbo].[Accounting]
                        ([UserID]
                        ,[Caption]
                        ,[Amount]
                        ,[ActType]
                        ,[CreateDate]
                        ,[Body])
                    VALUES
                        (@userID,
                        @caption,
                        @amount,
                        @actType,
                        @createDate,
                        @body)
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@userID", userID));
            parmList.Add(new SqlParameter("@caption", caption));
            parmList.Add(new SqlParameter("@amount", amount));
            parmList.Add(new SqlParameter("@actType", actType));
            parmList.Add(new SqlParameter("@createDate", DateTime.Now));
            parmList.Add(new SqlParameter("@body", body));

            try
            {
                DBHelper.ModifyDatas(connStr, dbCommand, parmList);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
            }
        }

        public static bool UpdateAccounting(int ID, string userID, string caption, int amount, int actType, string body)
        {
            // <<<check input>>>
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must be between 0 ~ 10,000,000");

            if (actType < 0 || actType > 1)
                throw new ArgumentException("Act Type must be 0 or 1");
            // <<< check input

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"UPDATE [Accounting]
                     SET
                        UserID          = @userID,
                        Caption         = @caption,
                        Amount         =@amount,
                        ActType        =@actType,
                        CreateDate   = @createDate,
                        Body             = @body
                    WHERE
                        ID = @id
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@userID", userID));
            parmList.Add(new SqlParameter("@caption", caption));
            parmList.Add(new SqlParameter("@amount", amount));
            parmList.Add(new SqlParameter("@actType", actType));
            parmList.Add(new SqlParameter("@createDate", DateTime.Now));
            parmList.Add(new SqlParameter("@body", body));
            parmList.Add(new SqlParameter("@id", ID));

            try
            {
                int effectRows = DBHelper.ModifyDatas(connStr, dbCommand, parmList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
                return false;
            }
        }

        public static void DeleteAccounting(int ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"DELETE [Accounting]
                    WHERE
                        ID = @id
                ";

            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@id", ID));

            try
            {
                DBHelper.ModifyDatas(connStr, dbCommand, parmList);
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex);
            }
         }
    }
}
