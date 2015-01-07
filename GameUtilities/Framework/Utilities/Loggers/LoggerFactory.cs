
namespace GameUtilities.Framework.Utilities.Loggers
{
    /// <summary>
    /// Factory for creating a logger. Makes a Null logger when in Release mode, and a Console logger when not
    /// </summary>
    public class LoggerFactory
    {
        /// <summary>
        /// Set the Logging level of any loggers created
        /// </summary>
        private static LoggerLevel mLoggerLevel = LoggerLevel.INFO;

        /// <summary>
        /// Set the logging level of any loggers created from this factory
        /// </summary>
        /// <param name="loggerLevel">logging level to set</param>
        public static void SetLoggingLevel(LoggerLevel loggerLevel)
        {
            mLoggerLevel = loggerLevel;
        }

        /// <summary>
        /// Creates an ILogger object
        /// </summary>
        /// <param name="Name">the name the logger should have</param>
        /// <returns>an ILogger</returns>
        public static ILogger CreateLogger(string Name)
        {
#if DEBUG
            return new ConsoleLogger(Name,mLoggerLevel);
#else
            return new NullLogger(Name,mLoggerLevel);
#endif
        }
    }
}
