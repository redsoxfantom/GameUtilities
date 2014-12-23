using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilities.Framework.Loggers
{
    /// <summary>
    /// A logger implementing the Null pattern
    /// </summary>
    public class NullLogger : BaseLogger
    {
        #region Constructors

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="Name">The name of the logger</param>
        /// <param name="level">The starting log level</param>
        public NullLogger(string Name, LoggerLevel level) : base(Name,level)
        {

        }

        /// <summary>
        /// The Constructor, sets Logging level to Info
        /// </summary>
        /// <param name="Name">The name of the Logger</param>
        public NullLogger(string Name) : base (Name)
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Does nothing
        /// </summary>
        /// <returns>an empty string</returns>
        protected override string getCallingMethod()
        {
            return string.Empty;
        }

        /// <summary>
        /// Prints a string to /dev/null
        /// </summary>
        /// <param name="level">Level the log is for</param>
        /// <param name="msg">The string to print</param>
        /// <param name="fore">foreground color</param>
        /// <param name="back">background color</param>
        protected override void Print(LoggerLevel level, string msg, ConsoleColor fore, ConsoleColor back)
        {
            //Does nothing
        }

        #endregion Methods
    }
}
