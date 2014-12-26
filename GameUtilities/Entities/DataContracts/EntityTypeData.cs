﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameUtilities.Entities.DataContracts
{
    /// <summary>
    /// Data contract for each Entity Type
    /// </summary>
    [DataContract]
    public class EntityTypeData
    {
        /// <summary>
        /// Name of the Type. Overrides the Entity name if not defined
        /// </summary>
        [DataMember(IsRequired=true,Order = 0)]
        public string Name { get; private set; }

        /// <summary>
        /// The assembly the Entity will instantiate
        /// </summary>
        [DataMember(IsRequired=true,Order=1)]
        public string Assembly { get; private set; }

        /// <summary>
        /// A list of Components associated with a Entity Type
        /// </summary>
        [DataMember(IsRequired=false,Order=2)]
        public ComponentList Components { get; private set; }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="name">The Entity Type Name</param>
        /// <param name="assembly">The Entity Assembly</param>
        /// <param name="components">The Entity's Components</param>
        public EntityTypeData(string name, string assembly, ComponentList components = null)
        {
            Name = name;
            Assembly = assembly;
            if(components == null)
            {
                Components = new ComponentList();
            }
            else
            {
                Components = components;
            }
        }
    }

    /// <summary>
    /// Data contract for a list of Components associated with each Entity type
    /// </summary>
    [DataContract]
    public class ComponentList : List<ComponentEntry>
    {

    }

    /// <summary>
    /// Data contract representing a single component in the ComponentList
    /// </summary>
    [DataContract]
    public class ComponentEntry
    {
        /// <summary>
        /// The assembly of the Component
        /// </summary>
        [DataMember(IsRequired=true,Order=0)]
        public string Component{get; private set;}

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="component">the component's assembly</param>
        public ComponentEntry(string component)
        {
            Component = component;
        }
    }
}