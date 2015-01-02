using GameUtilities.Framework.Engine;
using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

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
