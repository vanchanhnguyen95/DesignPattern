using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public enum LogLevel
    {
        Error,
        Info,
        Debug,
        Warn,
        Fatal
    }

    public interface ILog
    {
        bool WriteLog(string message, LogLevel level);
    }
}
