using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameUtilities.Entities.DataContracts
{
    /// <summary>
    /// Data contract for each Entity Type
    /// </summary>
    [DataContract(Name="EntityType",Namespace="")]
    public class EntityTypeData
    {
        /// <summary>
        /// Name of the Type. Overrides the Entity name if not defined
        /// </summary>
        [DataMember(IsRequired=true,Order = 0)]
        public string Name { get; private set; }

        /// <summary>
        /// A list of Components associated with a Entity Type
        /// </summary>
        [DataMember(IsRequired=false,Order=1)]
        public List<ComponentEntry> Components { get; private set; }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="name">The Entity Type Name</param>
        /// <param name="assembly">The Entity Assembly</param>
        /// <param name="components">The Entity's Components</param>
        public EntityTypeData(string name, List<ComponentEntry> components = null)
        {
            Name = name;
            if(components == null)
            {
                Components = new List<ComponentEntry>();
            }
            else
            {
                Components = components;
            }
        }
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
