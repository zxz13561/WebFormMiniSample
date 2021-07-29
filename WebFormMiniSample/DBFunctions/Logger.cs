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
            throw new ArgumentException("Error happend!!");
        }
    }
}
