
using System;
namespace GameUtilities.Framework.Utilities.Loggers
{
    /// <summary>
    /// Factory for creating a logger.
    /// </summary>
    public class LoggerFactory
    {
        /// <summary>
        /// Set the Logging level of any loggers created
        /// </summary>
        private static LoggerLevel mLoggerLevel = LoggerLevel.INFO;

        private static Type mLoggerType = typeof(NullLogger);

        /// <summary>
        /// Set the logging level of any loggers created from this factory
        /// </summary>
        /// <param name="loggerLevel">logging level to set</param>
        public static void SetLoggingLevel(LoggerLevel loggerLevel)
        {
            mLoggerLevel = loggerLevel;
        }

        /// <summary>
        /// Set the type of logger this Factory will create
        /// </summary>
        /// <param name="loggerType"></param>
        public static void SetLoggerType(Type loggerType)
        {
            mLoggerType = loggerType;
        }

        /// <summary>
        /// Creates an ILogger object
        /// </summary>
        /// <param name="Name">the name the logger should have</param>
        /// <returns>an ILogger</returns>
        public static ILogger CreateLogger(string Name)
        {
            object[] array = new object[] { Name, mLoggerLevel };
            return (ILogger)Activator.CreateInstance(mLoggerType, array);
        }
    }
}
