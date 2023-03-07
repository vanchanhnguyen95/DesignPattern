using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public sealed class Logger
    {
        /// <summary>
        /// thread-safety variable
        /// </summary>
        private static readonly object lockObject = new object();
        
        private static Logger instance = null;

        private string filePath = string.Empty;

        Logger() 
        {
            Configure();
        }

        /// <summary>
        /// Single instance
        /// </summary>
        public static Logger Instance
        {
            get
            {
                //implement simple thread-safety
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Configure the log file
        /// </summary>
        private void Configure()
        {
            this.filePath = @"D:\Chanh\log.txt";
        }

        /// <summary>
        /// Write message to log file
        /// </summary>
        public bool WriteLog(string message)
        {
            bool isOK = false;
            try
            {
                using (FileStream fileStream = new FileStream(this.filePath, FileMode.Append, FileAccess.Write))
                {
                    if (fileStream != null)
                    {
                        using (StreamWriter sw = new StreamWriter(fileStream))
                        {
                            sw.WriteLine(message);
                            sw.Close();
                            isOK = true;
                        }
                        fileStream.Close();
                    }
                }
            }
            catch
            {
                isOK = false;
            }
            
            return isOK;
        }
    }
}
