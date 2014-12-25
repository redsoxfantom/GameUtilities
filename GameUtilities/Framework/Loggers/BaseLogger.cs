using System.Diagnostics;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace GameUtilities.Framework.Loggers
{
    /// <summary>
    /// A generic Logger class. Prints to the console
    /// </summary>
    public class BaseLogger : ILogger
    {
        #region Constructors

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="Name">The name of the logger</param>
        /// <param name="level">The starting log level</param>
        public BaseLogger(string Name, LoggerLevel level = LoggerLevel.INFO)
        {
            LoggerName = Name;
            LoggingLevel = level;
        }

        #endregion Constructors

        #region Properties
        /// <summary>
        /// The current Logging level of the logger
        /// </summary>
        public LoggerLevel LoggingLevel 
        { 
            get
            {
                return mLevel;
            }
            set
            {
                mLevel = value;
            }
        }

        /// <summary>
        /// The Name of the logger
        /// </summary>
        public string LoggerName { get; set; }

        private LoggerLevel mLevel;

        #endregion Properties

        #region ILogger methods
        /// <summary>
        /// Returns whether the Logger will log Debug messages
        /// </summary>
        /// <returns>Whether the Logger is at Debug level</returns>
        public bool DebugEnabled()
        {
            return logLevelIsEnabled(LoggerLevel.DEBUG);
        }

        /// <summary>
        /// Returns whether the Logger will log Info messages
        /// </summary>
        /// <returns>Whether the Logger is at Info level</returns>
        public bool InfoEnabled()
        {
            return logLevelIsEnabled(LoggerLevel.INFO);
        }

        /// <summary>
        /// Returns whether the Logger will log Warn messages
        /// </summary>
        /// <returns>Whether the Logger is at Warn level</returns>
        public bool WarnEnabled()
        {
            return logLevelIsEnabled(LoggerLevel.WARN);
        }

        /// <summary>
        /// Returns whether the Logger will log Error messages
        /// </summary>
        /// <returns>Whether the Logger is at Error level</returns>
        public bool ErrorEnabled()
        {
            return logLevelIsEnabled(LoggerLevel.ERROR);
        }

        /// <summary>
        /// Prints an Info Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        public void Info(string msg)
        {
            string stackInfo = getCallingMethod();
            string finalmsg = string.Format("[{0}] {1}", stackInfo, msg);
            Print(LoggerLevel.INFO, finalmsg, ConsoleColor.White, ConsoleColor.Black);
        }

        /// <summary>
        /// Prints a Debug Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        public void Debug(string msg)
        {
            string stackInfo = getCallingMethod();
            string finalmsg = string.Format("[{0}] {1}", stackInfo, msg);
            Print(LoggerLevel.DEBUG, finalmsg, ConsoleColor.White, ConsoleColor.Blue);
        }

        /// <summary>
        /// Prints a Warn Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        public void Warn(string msg)
        {
            string stackInfo = getCallingMethod();
            string finalmsg = string.Format("[{0}] {1}", stackInfo, msg);
            Print(LoggerLevel.WARN, finalmsg, ConsoleColor.White, ConsoleColor.DarkYellow);
        }

        /// <summary>
        /// Prints an Error Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        public void Error(string msg)
        {
            string stackInfo = getCallingMethod();
            string finalmsg = string.Format("[{0}] {1}", stackInfo, msg);
            Print(LoggerLevel.ERROR, finalmsg, ConsoleColor.White, ConsoleColor.Red);
        }

        /// <summary>
        /// Prints a Fatal Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        public void Fatal(string msg)
        {
            string stackInfo = getCallingMethod();
            string finalmsg = string.Format("[{0}] {1}", stackInfo, msg);
            Print(LoggerLevel.FATAL, finalmsg, ConsoleColor.White, ConsoleColor.Magenta);
        }

        #endregion ILogger methods

        #region methods

        /// <summary>
        /// Chacks if the current logging level is less than the parameter
        /// </summary>
        /// <param name="level">Level to check against</param>
        /// <returns>Whether the current level is less than 'level'</returns>
        protected bool logLevelIsEnabled(LoggerLevel level)
        {
            return LoggingLevel >= level;
        }

        /// <summary>
        /// Gets the method at level 'stackLevel' of the program stack
        /// </summary>
        /// <param name="stackLevel">the level of the stack to retrive</param>
        /// <returns>A formatted string describing the method</returns>
        protected virtual string getCallingMethod()
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = null;
            MethodBase method = null;
            Assembly methodAssembly = null;
            Assembly baseAssembly = Assembly.GetAssembly(typeof(BaseLogger));
            for (int i = 0; i < trace.FrameCount; i++)
            {
                frame = trace.GetFrame(i);
                method = frame.GetMethod();
                methodAssembly = method.DeclaringType.Assembly;
                if(!(methodAssembly == baseAssembly))
                {
                    break;
                }
            }

            string retVal = string.Format("{0}.{1}",method.DeclaringType,method.Name);
            return retVal;
        }

        /// <summary>
        /// Overriden by child classes
        /// </summary>
        /// <param name="level">Level the log is for</param>
        /// <param name="msg">The string to print</param>
        /// <param name="fore">foreground color</param>
        /// <param name="back">background color</param>
        protected virtual void Print(LoggerLevel level, string msg, ConsoleColor fore, ConsoleColor back)
        { }

        #endregion methods
    }
}
