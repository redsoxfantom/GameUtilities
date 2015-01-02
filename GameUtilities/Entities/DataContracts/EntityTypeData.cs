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
        public ComponentEntry Components { get; private set; }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="name">The Entity Type Name</param>
        /// <param name="assembly">The Entity Assembly</param>
        /// <param name="components">The Entity's Components</param>
        public EntityTypeData(string name, ComponentEntry components = null)
        {
            Name = name;
            if(components == null)
            {
                Components = new ComponentEntry();
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
    [CollectionDataContract(ItemName="Component")]
    public class ComponentEntry : List<string>
    {}
}
