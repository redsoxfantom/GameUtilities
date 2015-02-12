using GameUtilities.Framework.Utilities.Loggers;
using System;
using System.Collections.Generic;

namespace GameUtilitiesUnitTests.UnitTestUtilities
{
    /// <summary>
    /// Logger utility class for use with Unit tests
    /// </summary>
    public class LoggerUtility : BaseLogger
    {
        /// <summary>
        /// Dictionary containing all messages passed to this logger
        /// </summary>
        private Dictionary<LoggerLevel, List<string>> mMessagesDictionary;

        /// <summary>
        /// List of all Debug messages printed
        /// </summary>
        public List<string> DebugMessages
        {
            get
            {
                return mMessagesDictionary[LoggerLevel.DEBUG];
            }
        }

        /// <summary>
        /// List of all Info messages printed
        /// </summary>
        public List<string> InfoMessages
        {
            get
            {
                return mMessagesDictionary[LoggerLevel.INFO];
            }
        }

        /// <summary>
        /// List of all Warn messages printed
        /// </summary>
        public List<string> WarnMessages
        {
            get
            {
                return mMessagesDictionary[LoggerLevel.WARN];
            }
        }

        /// <summary>
        /// List of all Error messages printed
        /// </summary>
        public List<string> ErrorMessages
        {
            get
            {
                return mMessagesDictionary[LoggerLevel.ERROR];
            }
        }

        /// <summary>
        /// List of all Fatal messages printed
        /// </summary>
        public List<string> FatalMessages
        {
            get
            {
                return mMessagesDictionary[LoggerLevel.FATAL];
            }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="Name">The name of the Logger</param>
        public LoggerUtility(string Name) : base(Name)
        {
            mMessagesDictionary = new Dictionary<LoggerLevel, List<string>>();
            foreach(Enum val in Enum.GetValues(typeof(LoggerLevel)))
            {
                mMessagesDictionary.Add((LoggerLevel)val,new List<string>());
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name">The name of the logger</param>
        /// <param name="level">the logging level of the logger</param>
        public LoggerUtility(string Name, LoggerLevel level) : base(Name,level)
        {
            mMessagesDictionary = new Dictionary<LoggerLevel, List<string>>();
            foreach (Enum val in Enum.GetValues(typeof(LoggerLevel)))
            {
                mMessagesDictionary.Add((LoggerLevel)val, new List<string>());
            }
        }

        /// <summary>
        /// Log the attempt to print, and take no action
        /// </summary>
        /// <param name="level">Logger level</param>
        /// <param name="msg">string to print</param>
        /// <param name="fore">unused</param>
        /// <param name="back">unused</param>
        protected override void Print(LoggerLevel level, string msg, System.ConsoleColor fore, System.ConsoleColor back)
        {
            mMessagesDictionary[level].Add(msg);
        }
    }
}
