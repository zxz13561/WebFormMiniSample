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
            string LogPath = "E:\\Practice\\Log.log";
            string FolderPath = System.IO.Path.GetDirectoryName(LogPath);

            if (!System.IO.Directory.Exists(FolderPath))
                System.IO.Directory.CreateDirectory(FolderPath);

            if (!System.IO.File.Exists(LogPath))
                System.IO.File.Create(LogPath);

            System.IO.File.AppendAllText(LogPath, msg);
            throw ex;
        }
    }
}
