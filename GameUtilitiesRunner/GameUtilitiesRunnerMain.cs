using GameUtilities.Framework.Utilities.Loggers;
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
        /// The error string to display when on an error
        /// </summary>
        private static string UsageString =
            "USAGE: GameUtilitiesRunner.exe -world <world name> -path <path\\to\\config\\directory>";

        static void Main(string[] args)
        {
            ParseArgs(args);

            GameUtilitiesRunnerProcessor proc = new GameUtilitiesRunnerProcessor(mWorld, mPath);
            proc.Run();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Parse out the arguments passed to the program
        /// </summary>
        /// <param name="args">the system arguments</param>
        private static void ParseArgs(string[] args)
        {
            if(args.Length != 4)
            {
                Console.WriteLine(UsageString);
                throw new InvalidOperationException("Invalid arguments");
            }

            for(int i = 0; i < 4; i += 2)
            {
                switch(args[i])
                {
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
