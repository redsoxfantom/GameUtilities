using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilities.Framework.Utilities.Loggers
{
    /// <summary>
    /// Logger that writes to the Console and a File (stored in ./Logs/{Logger Name}
    /// </summary>
    class FileConsoleLogger : ConsoleLogger
    {
        /// <summary>
        /// The writer
        /// </summary>
        private StreamWriter writer;

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="Name">The name of the logger</param>
        /// <param name="level">The starting log level</param>
        public FileConsoleLogger(string Name, LoggerLevel level) : base(Name,level)
        {
            Directory.CreateDirectory(".\\Logs");
            writer = new StreamWriter(string.Format(".\\Logs\\{0}.txt",Name));
        }

        /// <summary>
        /// The Constructor, sets Logging level to Info
        /// </summary>
        /// <param name="Name">The name of the Logger</param>
        public FileConsoleLogger(string Name) : base(Name)
        {
            Directory.CreateDirectory(".\\Logs");
            writer = new StreamWriter(string.Format(".\\Logs\\{0}.txt", Name));
        }

        /// <summary>
        /// Prints a string to the console and to the File
        /// </summary>
        /// <param name="level">Level the log is for</param>
        /// <param name="msg">The string to print</param>
        /// <param name="fore">foreground color</param>
        /// <param name="back">background color</param>
        protected override void Print(LoggerLevel level, string msg, ConsoleColor fore, ConsoleColor back)
        {
            base.Print(level, msg, fore, back);
            if(logLevelIsEnabled(level))
            {
                string finalMsg = string.Format("{0}-{1}-{2}", Enum.GetName(typeof(LoggerLevel), level), LoggerName, msg);
                writer.WriteLine(finalMsg);
            }
        }

        /// <summary>
        /// Close the Streamwriter
        /// </summary>
        public override void Terminate()
        {
            writer.Flush();
            writer.Close();
        }
    }
}
