﻿using GameUtilities.Framework.Engine;
using GameUtilities.Framework.Utilities.Loggers;
using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace GameUtilitiesRunner
{
    /// <summary>
    /// Handles actually running the Engine
    /// </summary>
    public class GameUtilitiesRunnerProcessor
    {
        /// <summary>
        /// Name of the World to initialize
        /// </summary>
        private string mWorld;

        /// <summary>
        /// Path to the config directory to use
        /// </summary>
        private string mPathToConfig;

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="world">Name of the World to load initially</param>
        /// <param name="PathToConfig">Path to the config directory</param>
        public GameUtilitiesRunnerProcessor(string world, string PathToConfig)
        {
            mWorld = world;
            mPathToConfig = PathToConfig;
        }

        /// <summary>
        /// Run the Engine
        /// </summary>
        public void Run()
        {
            IEngine engine = new Engine();

            using (var game = new GameWindow())
            {
                game.Load += (sender, e) =>
                {
                    engine.Init(mPathToConfig, mWorld);
                    game.VSync = VSyncMode.On;
                    GL.ClearColor(Color.Red);
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };

                game.UpdateFrame += (sender, e) =>
                {
                    engine.Update(e.Time);
                    if (game.Keyboard[Key.Escape])
                    {
                        engine.Terminate();
                        game.Exit();
                    }
                };

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    engine.Draw(e.Time);
                    game.SwapBuffers();
                };

                game.Run();
            }
        }
    }
}
