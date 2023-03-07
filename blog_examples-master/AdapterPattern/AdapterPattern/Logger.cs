using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class Logger : ILog
    {
        /// <summary>  
        /// thread-safety variable  
        /// </summary>  
        private static readonly object lockObject = new object();

        private static Logger instance = null;

        /// <summary>
        /// Adaptee
        /// </summary>
        private log4net.ILog myLog4net;

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
            log4net.Config.XmlConfigurator.Configure();
            myLog4net = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }  

        /// <summary>
        /// Implement interface's method
        /// </summary>
        /// <param name="level"></param>
        /// <param name="ex"></param>
        public bool WriteLog(string message, LogLevel level = LogLevel.Debug)
        {
            if (myLog4net != null)
            {
                switch (level)
                {
                    case LogLevel.Error:
                        if (myLog4net.IsErrorEnabled)
                            myLog4net.Error(message);
                        break;

                    case LogLevel.Debug:
                        if (myLog4net.IsDebugEnabled)
                            myLog4net.Debug(message);
                        break;

                    case LogLevel.Fatal:
                        if (myLog4net.IsFatalEnabled)
                            myLog4net.Fatal(message);
                        break;

                    case LogLevel.Info:
                        if (myLog4net.IsInfoEnabled)
                            myLog4net.Info(message);
                        break;

                    case LogLevel.Warn:
                        if (myLog4net.IsWarnEnabled)
                            myLog4net.Warn(message);
                        break;
                }
                return true;
            }

            return false;
        }
    }
}
