

using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Utility
{
    public class LogInfo
    {
        private static ReaderWriterLockSlim _readwriteLock = new ReaderWriterLockSlim();
        private static void WriteThreadSafeFile(string filePath, string message)
        {
            // Set Status to Locked
            _readwriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine("-------------------------------");
                    streamWriter.WriteLine("[{0: MM/dd/yyyy hh:mm:ss tt}]: {1}", DateTime.Now, message);
                    streamWriter.WriteLine("-------------------------------");
                    streamWriter.Close();
                }

            }
            catch (Exception ex)
            {
                string readwriteLockErrorFile = Path.ChangeExtension(filePath, null) + "_readWriteLockError.txt";
                using (StreamWriter streamWriter = File.AppendText(readwriteLockErrorFile))
                {
                    streamWriter.WriteLine("-------------------------------");
                    streamWriter.WriteLine($"Catch Exception:" + ex.Message);
                    streamWriter.WriteLine($"Catch Exception:" + ex.InnerException);
                    streamWriter.WriteLine("-------------------------------");


                    streamWriter.WriteLine($"Catch Exception:" + ex.StackTrace);
                    streamWriter.WriteLine("[{0:MM/dd/yyyy hh:mm:ss tt}]: {1}", DateTime.Now, message);
                    streamWriter.Close();
                }
            }
            finally
            {
                // Release Lock
                _readwriteLock.ExitWriteLock();
            }
        }
        public static void WriteLog(string message)
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath).Create();
            var filePath = $"{dirPath}log_{DateTime.Now: MMddyyyy}.txt".Replace("/", "");
            WriteThreadSafeFile(filePath, message);

        }

        public static void WriteLog(string fileName, string message)
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath).Create();
            var filePath = $"{dirPath}{fileName}_Log_{DateTime.Now: MMddyyyy}.txt".Replace("/", "");
            WriteThreadSafeFile(filePath, message);
        }

        public static void WriteErrorLog(string fileName, string className, string methodName, Exception exception)
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath).Create();

            string message = $"{className} :: {methodName} Error_Message==> {exception.Message} \n\n";

            message += $"{className} :: {methodName} Error_InnerException ==> {exception.InnerException} \n\n";
            message += $"{className} :: {methodName} Error_BaseException ==> {exception.GetBaseException().ToString()} \n\n";
            message += $"{className} :: {methodName} Error_StackTrace ==> {ToLogString(exception, Environment.StackTrace)} \n\n";

            var filePath = $"{dirPath}{fileName}_Log_{DateTime.Now: MMddyyyy}.txt".Replace("/", "");
            WriteThreadSafeFile(filePath, message);
        }

        public static string ToLogString(Exception exception, string environmentStackTrace)
        {
            List<string> environmentStackTraceLines = GetUserStackTraceLines(environmentStackTrace);
            environmentStackTraceLines.RemoveAt(0);
            List<string> stackTraceLines = GetStackTraceLines(exception.StackTrace); stackTraceLines.AddRange(environmentStackTraceLines);
            //Remove duplicate lines
            if (stackTraceLines.Count > 0)
            {
                stackTraceLines = stackTraceLines.Distinct().ToList();
            }

            string fullStackTrace = String.Join(Environment.NewLine, stackTraceLines);
            string LogMessage = exception.Message + Environment.NewLine + fullStackTrace; return LogMessage;
        }

        private static List<string> GetStackTraceLines(string stackTrace)
        {
            return stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        }


        private static List<string> GetUserStackTraceLines(string fullStackTrace)
        {
            List<string> outputList = new List<string>();
            Regex regex = new Regex(@"([^\)]*\)) in (.*):Line (\d)*$");
            List<string> stackTraceLines = GetStackTraceLines(fullStackTrace);

            foreach (string stackTraceLine in stackTraceLines)
            {
                if (!regex.IsMatch(stackTraceLine))
                {
                    continue;
                }
                outputList.Add(stackTraceLine);

            }
            return outputList;
        }
    }

    
}
