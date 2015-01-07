using System.Diagnostics;
using System;

namespace GameUtilities.Framework.Utilities.Loggers
{
    /// <summary>
    /// A generic Logger class. Prints to the console
    /// </summary>
    public class ConsoleLogger : BaseLogger
    {
        #region Fields

        /// <summary>
        /// Synchronizes access to the console
        /// </summary>
        protected static Object mLock;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="Name">The name of the logger</param>
        /// <param name="level">The starting log level</param>
        public ConsoleLogger(string Name, LoggerLevel level) : base(Name,level)
        {
            mLock = new Object();
        }

        /// <summary>
        /// The Constructor, sets Logging level to Info
        /// </summary>
        /// <param name="Name">The name of the Logger</param>
        public ConsoleLogger(string Name) : base (Name)
        {
            mLock = new Object();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Reset the console to default colors
        /// </summary>
        protected void ConsoleReset()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Sets the console to a particular color
        /// </summary>
        /// <param name="fore">foreground color</param>
        /// <param name="back">background color</param>
        protected void SetConsoleColor(ConsoleColor fore, ConsoleColor back)
        {
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
        }

        /// <summary>
        /// Prints a string to the console
        /// </summary>
        /// <param name="level">Level the log is for</param>
        /// <param name="msg">The string to print</param>
        /// <param name="fore">foreground color</param>
        /// <param name="back">background color</param>
        protected override void Print(LoggerLevel level, string msg, ConsoleColor fore, ConsoleColor back)
        {
            lock (mLock)
            {
                if (logLevelIsEnabled(level))
                {
                    SetConsoleColor(fore, back);
                    string finalMsg = string.Format("{0}-{1}-{2}", Enum.GetName(typeof(LoggerLevel), level), LoggerName, msg);
                    Console.WriteLine(finalMsg);
                    ConsoleReset();
                }
            }
        }

        #endregion Methods
    }
}
