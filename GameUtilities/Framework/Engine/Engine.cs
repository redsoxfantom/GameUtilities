﻿using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Worlds.DataContracts;
using GameUtilities.Worlds;
using GameUtilities.Framework.Utilities.Loggers;
using System;
using System.Collections.Generic;
using GameUtilities.Services;

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
        /// List of all the services in use by the Engine
        /// </summary>
        private List<IService> mServicesList;

        /// <summary>
        /// The Constructor
        /// </summary>
        public Engine()
        {
            mLogger = LoggerFactory.CreateLogger("ENGINE");
            mServicesList = new List<IService>();
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

            foreach(IService service in mServicesList)
            {
                service.Init(mContext);
            }

            mWorld = WorldFactory.CreateWorld(world, mContext);
            mLogger.Info("Done initializing Engine");
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Update was called</param>
        public void Update(double timeSinceLastFrame)
        {
            mContext.MessageRouter.Update();

            try
            {
                mWorld.Update(timeSinceLastFrame);
            }
            catch(Exception e)
            {
                mLogger.Warn("Error updating world", e);
            }

            foreach(IService service in mServicesList)
            {
                service.Update(timeSinceLastFrame);
            }
        }

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Draw was called</param>
        public void Draw(double timeSinceLastFrame)
        {
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
            mContext.MessageRouter.Terminate();
            foreach(IService service in mServicesList)
            {
                service.Terminate();
            }

            mLogger.Info("Engine Shutdown Complete");
            mLogger.Terminate();
        }
    }
}
