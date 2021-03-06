using Architecture.Web.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Web.Extensions
{
    public static class ExceptionExtension
    {
        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem,
            Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        public static IEnumerable<Exception> GetAllExceptions(this Exception exception)
        {
            yield return exception;

            if (exception is AggregateException)
            {
                var aggrEx = exception as AggregateException;
                foreach (Exception innerEx in aggrEx.InnerExceptions.SelectMany(e => e.GetAllExceptions()))
                {
                    yield return innerEx;
                }
            }
            else if (exception.InnerException != null)
            {
                foreach (Exception innerEx in exception.InnerException.GetAllExceptions())
                {
                    yield return innerEx;
                }
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        public static string GetAllMessages(this Exception exception)
        {
            var messages = exception
                .FromHierarchy(ex => ex.InnerException)
                .Select(ex => ex.Message).ToList();
            return string.Join(Environment.NewLine, messages);
        }

        public static IEnumerable<ApplicationError> GetAll(this Exception exception)
        {
            var dateTime = DateTime.UtcNow;
            var exceptions = exception.FromHierarchy(ex => ex.InnerException);

            var list = from ex in exceptions
                       let st = new StackTrace(ex, true)
                       let frame = st.GetFrame(st.FrameCount - 1)
                       let declaringType = frame?.GetMethod().DeclaringType
                       select new ApplicationError
                       {
                           Id = Guid.NewGuid().ToString().ToLower(),
                           ErrorTime = dateTime,
                           FileName = Path.GetFileName(frame?.GetFileName()),
                           MethodName = frame?.GetMethod().Name,
                           LineNumber = frame==null?0:frame.GetFileLineNumber(),
                           Message = ex.Message,
                           ColumnNumber = frame == null ? 0 : frame.GetFileColumnNumber(),
                           EntityName = declaringType != null ? declaringType.Name : frame?.GetFileName(),
                           EntityFullName = declaringType != null ? declaringType.FullName : frame?.GetFileName(),
                           StackTrace = ex.StackTrace,
                       };

            return list;
        }

        public static void ToTextFileLog(this Exception ex)
        {
            var startupPath = Directory.GetCurrentDirectory();

            ToTextFileLog(ex, startupPath);
        }

        public static void ToTextFileLog(this Exception ex, string startupPath, string folderName = "Logs", string fileName = "ErrorLog", string extention = ".txt")
        {
            string message = string.Empty;
            var toDay = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var filePath = startupPath + "\\" + folderName + "\\" + fileName + "_" + toDay + extention;

            foreach (var item in ex.GetAll())
            {

                var msg = "--------------------------------------------------" + Environment.NewLine;

                msg += "Date: " + toDay + Environment.NewLine
                        + "Time: " + DateTime.UtcNow.ToString("hh:mm:ss") + Environment.NewLine
                        + "File Name: " + item.FileName + Environment.NewLine
                        + "Entity Name: " + item.EntityFullName + Environment.NewLine
                        + "Method Name: " + item.MethodName + Environment.NewLine
                        + "Line Number: " + item.LineNumber + Environment.NewLine
                        + "Column Number: " + item.ColumnNumber + Environment.NewLine
                        + "Message : " + item.Message + Environment.NewLine
                        + "Stack Trace : " + item.StackTrace + Environment.NewLine;
                msg += "--------------------------------------------------" + Environment.NewLine;
                message += msg;

            }

            File.AppendAllText(filePath, message);
        }

        public static void ToWriteMessageLog(this string message, string methodName = "", string folderName = "CusomLog", string fileName = "MessageLog.txt")
        {
            var startupPath = new DirectoryInfo(Path.GetDirectoryName(
                Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path))).Parent.FullName;

            var msg = "--------------------------------------------------" + Environment.NewLine;
            msg += "Date: " + DateTime.UtcNow.ToString("yyyy-MM-dd") + Environment.NewLine
                 + "Time: " + DateTime.UtcNow.ToString("hh:mm:ss") + Environment.NewLine;

            if (!string.IsNullOrWhiteSpace(methodName))
            {
                msg += "Function : " + methodName + Environment.NewLine;
            }
            msg += "Message : " + message + Environment.NewLine;
            msg += "--------------------------------------------------" + Environment.NewLine;

            var filePath = startupPath + "\\" + folderName + "\\" + fileName;
            File.AppendAllText(filePath, msg);
        }

        public static void ToJsonFileLog(this Exception model)
        {
            {
                try
                {
                    var startupPath = new DirectoryInfo(Path.GetDirectoryName(
                                    Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path))).Parent.FullName;

                    ToJsonFileLog(model, startupPath);
                }
                catch (Exception ex)
                {
                    ex.ToTextFileLog();
                }
            }
        }

        public static void ToJsonFileLog(this Exception model, string startupPath, string fileName = "ErrorLog.txt")
        {
            var strLogs = JsonConvert.SerializeObject(model.GetAll());
            File.AppendAllText(startupPath + "\\" + fileName, strLogs);
        }

        public static void ToWriteLog(this Exception ex)
        {
            ex.ToTextFileLog();
        }
    }
}
