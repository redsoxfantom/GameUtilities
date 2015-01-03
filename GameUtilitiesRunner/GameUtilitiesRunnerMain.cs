using GameUtilities.Framework.Loggers;
using System;

namespace GameUtilitiesRunner
{
    /// <summary>
    /// Parses arguments and creates the world
    /// </summary>
    class GameUtilitiesRunnerMain
    {
        /// <summary>
        /// The path to the config directory
        /// </summary>
        private static string mPath = null;

        /// <summary>
        /// name of the world to initialize
        /// </summary>
        private static string mWorld = null;

        /// <summary>
        /// Logging level to initialize
        /// </summary>
        private static LoggerLevel mLoggingLevel = LoggerLevel.INFO;

        private static string UsageString =
            "USAGE: GameUtilitiesRunner.exe -loglevel {DEBUG,INFO,WARN,ERROR,FATAL} -world <world name> -path <path\\to\\config\\directory>";

        static void Main(string[] args)
        {
            ParseArgs(args);

            GameUtilitiesRunnerProcessor proc = new GameUtilitiesRunnerProcessor(mLoggingLevel, mWorld, mPath);
            proc.Run();

            Console.ReadKey();
        }

        /// <summary>
        /// Parse out the arguments passed to the program
        /// </summary>
        /// <param name="args">the system arguments</param>
        private static void ParseArgs(string[] args)
        {
            if(args.Length != 6)
            {
                Console.WriteLine(UsageString);
                throw new InvalidOperationException("Invalid arguments");
            }

            for(int i = 0; i < 6; i += 2)
            {
                switch(args[i])
                {
                    case "-loglevel":
                        mLoggingLevel = (LoggerLevel)Enum.Parse(typeof(LoggerLevel), args[i + 1]);
                        break;
                    case "-world":
                        mWorld = args[i + 1];
                        break;
                    case "-path":
                        mPath = args[i + 1];
                        break;
                    default:
                        Console.WriteLine(UsageString);
                        throw new InvalidOperationException(string.Format("Invalid argument: {0}",args[i]));
                }
            }

            if(string.IsNullOrEmpty(mWorld)||string.IsNullOrEmpty(mPath))
            {
                Console.WriteLine(UsageString);
                throw new InvalidOperationException("Invalid arguments");
            }
        }
    }
}
