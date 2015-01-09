using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Worlds.DataContracts;
using GameUtilities.Worlds;
using GameUtilities.Framework.Utilities.Loggers;
using System;

namespace GameUtilities.Framework.Engine
{
    public class Engine : IEngine
    {
        /// <summary>
        /// Pointer to the Engine's World
        /// </summary>
        private IWorld mWorld;

        /// <summary>
        /// The base Executable context for the Engine
        /// </summary>
        private IExecutableContext mContext;

        /// <summary>
        /// Logger for the Engine
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// The Constructor
        /// </summary>
        public Engine()
        {
            mLogger = LoggerFactory.CreateLogger("ENGINE");
        }

        /// <summary>
        /// Initialize the Engine. Creates the World and all the Services
        /// </summary>
        /// <param name="PathToConfig">Path to the Config directory</param>
        /// <param name="world"></param>
        public void Init(string PathToConfig, string world)
        {
            mLogger.Info(string.Format("Initializing engine with world: {0} and config path: {1}",world,PathToConfig));
            mContext = new BaseExecutableContext(PathToConfig);
            mWorld = WorldFactory.CreateWorld(world, mContext);

            //TODO: initialize services here

            mLogger.Info("Done initializing Engine");
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Update was called</param>
        public void Update(double timeSinceLastFrame)
        {
            mLogger.Debug(string.Format("Update called, timeSinceLastFrame={0}", timeSinceLastFrame));

            try
            {
                mWorld.Update(timeSinceLastFrame);
            }
            catch(Exception e)
            {
                mLogger.Warn("Error updating world", e);
            }

            //TODO: Update Services here
        }

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Draw was called</param>
        public void Draw(double timeSinceLastFrame)
        {
            mLogger.Debug(string.Format("Draw called, timeSinceLastFrame={0}", timeSinceLastFrame));

            try
            {
                mWorld.Draw(timeSinceLastFrame);
            }
            catch(Exception e)
            {
                mLogger.Warn("Error drawing world", e);
            }
        }

        /// <summary>
        /// Called to termminate the Engine
        /// </summary>
        public void Terminate()
        {
            mLogger.Info("Beginning Engine Shutdown...");
            mWorld.Terminate();
            //TODO: Shut down any Services

            mLogger.Info("Engine Shutdown Complete");
        }
    }
}
