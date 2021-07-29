﻿using System;
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

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                using(SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);

                    try
                    {
                        conn.Open();
                        var reader = comm.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        return dt;
                    }
                    catch (Exception ex)
                    {
                        Logger.LogWriter(ex);
                        return null;
                    }
                }
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

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@userID", userID);

                    try
                    {
                        conn.Open();
                        var reader = comm.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        if(dt.Rows.Count == 0)
                            return null;
                        else
                            return dt.Rows[0];

                    }
                    catch (Exception ex)
                    {
                        Logger.LogWriter(ex);
                        return null;
                    }
                }
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

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);
                    comm.Parameters.AddWithValue("@caption", caption);
                    comm.Parameters.AddWithValue("@amount", amount);
                    comm.Parameters.AddWithValue("@actType", actType);
                    comm.Parameters.AddWithValue("@createDate", DateTime.Now);
                    comm.Parameters.AddWithValue("@body", body);

                    try
                    {
                        conn.Open();
                        var reader = comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogWriter(ex);
                    }
                }
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

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);
                    comm.Parameters.AddWithValue("@caption", caption);
                    comm.Parameters.AddWithValue("@amount", amount);
                    comm.Parameters.AddWithValue("@actType", actType);
                    comm.Parameters.AddWithValue("@createDate", DateTime.Now);
                    comm.Parameters.AddWithValue("@body", body);
                    comm.Parameters.AddWithValue("@id", ID);

                    try
                    {
                        conn.Open();
                        int effectRows = comm.ExecuteNonQuery();

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

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@id", ID);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogWriter(ex);
                    }
                }
            }
        }
    }
}
