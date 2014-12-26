using System.Runtime.Serialization;
using OpenTK;
using GameUtilities.Framework.DataContracts;

namespace GameUtilities.Entities.DataContracts
{
    /// <summary>
    /// Data contract defining an Entity in the game World
    /// </summary>
    [DataContract]
    public class EntityData
    {
        /// <summary>
        /// The name of the entity. If not defined, the name of the Type will be used
        /// </summary>
        [DataMember(IsRequired = false, Order = 0)]
        public string Name { get; private set; }

        /// <summary>
        /// The assembly the Entity will instantiate
        /// </summary>
        [DataMember(IsRequired = true, Order = 1)]
        public string Assembly { get; private set; }

        /// <summary>
        /// The Type of Entity this is. Must be defined and must have the same name as an EntityType config file
        /// </summary>
        [DataMember(IsRequired=true, Order=2)]
        public string Type { get; private set; }

        /// <summary>
        /// A list of optional Data to feed to Components
        /// </summary>
        [DataMember(IsRequired=false,Order=3)]
        public DataSet DataSet { get; private set; }

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="type">The Type of entity</param>
        /// <param name="name">The entity's name</param>
        /// <param name="dataSet">optional data</param>
        public EntityData(string type, string name = null, DataSet dataSet = null)
        {
            Type = type;
            Name = name;
            if(dataSet == null)
            {
                DataSet = new DataSet();
            }
            else
            {
                DataSet = dataSet;
            }
        }
    }
}
