using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilities.Loggers
{
    /// <summary>
    /// Labels what level the logger logs at. A logger at a certain level (i.e, ERROR)
    /// will also log levels below it (i.e, FATAL).
    /// </summary>
    public enum LoggerLevel
    {
        FATAL = 0,
        ERROR,
        WARN,
        INFO,
        DEBUG
    }
}
