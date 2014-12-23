
namespace GameUtilities.Framework.Loggers
{
    /// <summary>
    /// Factory for creating a logger. Makes a Null logger when in Release mode, and a Console logger when not
    /// </summary>
    class LoggerFactory
    {
        /// <summary>
        /// Creates an ILogger object
        /// </summary>
        /// <param name="Name">the name the logger should have</param>
        /// <returns>an ILogger</returns>
        static ILogger CreateLogger(string Name)
        {
#if DEBUG
            return new ConsoleLogger(Name);
#else
            return new NullLogger(Name);
#endif
        }
    }
}
