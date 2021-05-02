using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Extensions
{
    public static class LoggerExtension
    {
        public static void ToTextFileLog(string message)
        {
            var startupPath = Directory.GetCurrentDirectory();

            ToTextFileLog(message, startupPath);
        }

        public static void ToTextFileLog(string message, string startupPath, string folderName = "Logs", string fileName = "ErrorLog", string extention = ".txt")
        {
            var toDay = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var filePath = startupPath + "\\" + folderName + "\\" + fileName + "_" + toDay + extention;

            var msg = message + Environment.NewLine;
            File.AppendAllText(filePath, msg);
        }

        public static void ToWriteLog(string message)
        {
            ToTextFileLog(message);
        }
    }
}
