using GameUtilities.Framework.Engine;
using System;

namespace GameUtilitiesRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Init(".\\Config","World1");

            Console.ReadKey();
        }
    }
}
