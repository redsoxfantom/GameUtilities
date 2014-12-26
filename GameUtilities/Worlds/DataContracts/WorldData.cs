﻿using System.Runtime.Serialization;
using GameUtilities.Entities.DataContracts;
using System.Collections.Generic;

namespace GameUtilities.Worlds.DataContracts
{
    /// <summary>
    /// A Data Contract for reading in World data files
    /// </summary>
    [DataContract]
    public class WorldData
    {
        /// <summary>
        /// Stores the Name of the world
        /// </summary>
        [DataMember(IsRequired=true,Order=0)]
        public string Name { get; private set; }

        /// <summary>
        /// Stores a list of all entities defined in the world
        /// </summary>
        [DataMember(IsRequired=false,Order=1)]
        public EntityDataSet Entities { get; private set; }

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="name">The World's Name</param>
        /// <param name="entities">The list of entities</param>
        public WorldData(string name, EntityDataSet entities = null)
        {
            Name = name;
            if(entities != null)
            {
                Entities = entities;
            }
            else
            {
                Entities = new EntityDataSet();
            }
        }
    }

    /// <summary>
    /// Data contract defining a list of Entities in use in the world
    /// </summary>
    [DataContract]
    public class EntityDataSet:List<EntityData>
    {

    }
}