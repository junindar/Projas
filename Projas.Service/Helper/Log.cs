using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projas.Service.Helper
{
    public class Log
    {
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        public static void WriteLog(string ProjectName, string Message)
        {

            string LogFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Log";


            if (!Directory.Exists(LogFolder)) Directory.CreateDirectory(LogFolder);

            String LogFileName = ProjectName + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            LogFileName = LogFolder + @"\" + LogFileName;
            string msg = DateTime.Now + ": " + Message + Environment.NewLine;

            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                using (StreamWriter sw = File.AppendText(LogFileName))
                {
                    sw.WriteLine(msg);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }

        }

    }
}
