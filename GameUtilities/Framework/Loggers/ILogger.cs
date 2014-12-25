using System;

namespace GameUtilities.Framework.Loggers
{
    public interface ILogger
    {
        /// <summary>
        /// The current Logging level of the logger
        /// </summary>
        LoggerLevel LoggingLevel{get;set;}

        /// <summary>
        /// The Name of the logger
        /// </summary>
        string LoggerName { get; set; }

        /// <summary>
        /// Returns whether the Logger will log Debug messages
        /// </summary>
        /// <returns>Whether the Logger is at Debug level</returns>
        bool DebugEnabled();

        /// <summary>
        /// Returns whether the Logger will log Info messages
        /// </summary>
        /// <returns>Whether the Logger is at Info level</returns>
        bool InfoEnabled();

        /// <summary>
        /// Returns whether the Logger will log Warn messages
        /// </summary>
        /// <returns>Whether the Logger is at Warn level</returns>
        bool WarnEnabled();

        /// <summary>
        /// Returns whether the Logger will log Error messages
        /// </summary>
        /// <returns>Whether the Logger is at Error level</returns>
        bool ErrorEnabled();

        /// <summary>
        /// Prints an Info Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        void Info(String msg);

        /// <summary>
        /// Prints a Debug Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        void Debug(String msg);

        /// <summary>
        /// Prints a Warn Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        void Warn(String msg);

        /// <summary>
        /// Prints an Error Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        void Error(String msg);

        /// <summary>
        /// Prints a Fatal Message
        /// </summary>
        /// <param name="msg">The message to print</param>
        void Fatal(String msg);

        /// <summary>
        /// Adds a logger as a child to this one
        /// Child loggers take on the parent's Logging Level
        /// </summary>
        /// <param name="logger">the logger to add</param>
        void AddChildLogger(ILogger logger);

        /// <summary>
        /// Removes a child logger from this one
        /// </summary>
        /// <param name="logger">the logger to remove</param>
        void RemoveChildLogger(ILogger logger);
    }

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
