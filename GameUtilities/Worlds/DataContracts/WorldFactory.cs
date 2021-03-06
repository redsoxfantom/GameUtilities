﻿using GameUtilities.Framework.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;
using System;

namespace GameUtilities.Worlds.DataContracts
{
    /// <summary>
    /// A factory for creating a fully populated World Instance
    /// </summary>
    public class WorldFactory
    {
        /// <summary>
        /// Creates an instance of a World from a config file
        /// </summary>
        /// <param name="path">the path to the File defining the world to create</param>
        /// <returns>an IWorld object</returns>
        public static IWorld CreateWorld(string worldName, IExecutableContext context)
        {
            string path = context.ConfigManager.FindWorld(worldName);
            WorldData worldData = DataContractFactory.DeserializeObject<WorldData>(path);
            Type worldType = Type.GetType(worldData.Assembly);
            Object[] objArray = { worldData };
            IWorld world = (IWorld)Activator.CreateInstance(worldType, objArray);
            world.Init(context);

            return world;
        }
    }
}
