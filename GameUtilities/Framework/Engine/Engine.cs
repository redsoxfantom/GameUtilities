using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Worlds.DataContracts;
using GameUtilities.Worlds;
using GameUtilities.Framework.Utilities.Loggers;
using System;
using System.Collections.Generic;
using GameUtilities.Services;
using GameUtilities.Framework.DataContracts;
using GameUtilities.Framework.Engine.DataContracts;

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
            mServicesList = new List<IService>();
        }

        /// <summary>
        /// Initialize the Engine. Creates the World and all the Services
        /// </summary>
        /// <param name="PathToConfig">Path to the Config directory</param>
        /// <param name="world"></param>
        public void Init(string PathToConfig, string world)
        {
            mContext = new BaseExecutableContext(PathToConfig);
            string pathToEngineConfigFile = mContext.ConfigManager.FindEngineConfig();
            EngineConfigDataContract engineConfig = DataContractFactory.DeserializeObject<EngineConfigDataContract>(pathToEngineConfigFile);

            //Initialize the Logger
            LoggerFactory.SetLoggerType(Type.GetType(engineConfig.LoggerType));
            LoggerFactory.SetLoggingLevel(engineConfig.LogLevel);
            mLogger = LoggerFactory.CreateLogger("ENGINE");
            mLogger.Info(string.Format("Initializing engine with world: {0} and config path: {1}",world,PathToConfig));

            foreach(string assembly in engineConfig.ServicesList)
            {
                try
                {
                    mLogger.Debug(string.Format("Attempting to create service {0}", assembly));
                    Type assemblyType = Type.GetType(assembly);
                    if(assembly == null)
                    {
                        throw new Exception(string.Format("Service assembly {0} not found!", assembly));
                    }
                    IService service = (IService)Activator.CreateInstance(Type.GetType(assembly));
                    mServicesList.Add(service);
                    mLogger.Debug(string.Format("Successfuly created service {0}", assembly));
                }
                catch(Exception e)
                {
                    mLogger.Warn("Error creating Service", e);
                }
            }
            

            foreach(IService service in mServicesList)
            {
                try
                {
                    mLogger.Debug(string.Format("Initializing service {0}",service.ToString()));
                    service.Init(mContext);
                    mLogger.Debug(string.Format("Successfully initialized service {0}", service.ToString()));
                }
                catch(Exception e)
                {
                    mLogger.Warn("Error initializing Service", e);
                }
            }

            try
            {
                mLogger.Debug(string.Format("Attempting to create world {0}",world));
                mWorld = WorldFactory.CreateWorld(world, mContext);
                mLogger.Debug(string.Format("Successfully created world {0}", world));
            }
            catch(Exception e)
            {
                mLogger.Warn("Error initializing world", e);
            }
            mLogger.Info("Done initializing Engine");
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Update was called</param>
        public void Update(double timeSinceLastFrame)
        {
            mContext.MessageRouter.Update();

            foreach (IService service in mServicesList)
            {
                try
                {
                    service.Update(timeSinceLastFrame);
                }
                catch(Exception e)
                {
                    mLogger.Warn("Error updating service", e);
                }
            }

            try
            {
                mWorld.Update(timeSinceLastFrame);
            }
            catch(Exception e)
            {
                mLogger.Warn("Error updating world", e);
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
            foreach(IService service in mServicesList)
            {
                service.Terminate();
            }

            mContext.MessageRouter.Terminate();
            mLogger.Info("Engine Shutdown Complete");
            mLogger.Terminate();
        }
    }
}
