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

            using(var game = new GameWindow())
            {
                game.Load += (sender, e) =>
                {
                    engine.Init(".\\Config", "World1");
                    game.VSync = VSyncMode.On;
                    GL.ClearColor(Color.Black);
                };
                
                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };
                
                game.UpdateFrame += (sender, e) =>
                {
                    engine.Update(0);
                    if (game.Keyboard[Key.Escape])
                    {
                        engine.Terminate();
                        game.Exit();
                    }
                };

                game.RenderFrame += (sender, e) =>
                {
                    engine.Draw(0);
                    game.SwapBuffers();
                };

                game.Run();
            }
        }
    }
}
