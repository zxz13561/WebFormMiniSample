using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFunctions
{
    public class Logger
    {
        public static void LogWriter(Exception ex)
        {
            string msg =
                $@" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                        {ex.ToString()}
                ";

            System.IO.File.AppendAllText("E:\\Practice\\Log.log", msg);
            throw ex;
        }
    }
}
