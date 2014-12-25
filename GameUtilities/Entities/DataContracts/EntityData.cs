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
        /// The Assembly that this Entity will use. If not defined, the assembly defined in the Type will be used
        /// </summary>
        [DataMember(IsRequired=false,Order=1)]
        public string Assembly { get; private set; }

        /// <summary>
        /// The Type of Entity this is. Must be defined and must have the same name as an EntityType config file
        /// </summary>
        [DataMember(IsRequired=true, Order=2)]
        public string Type { get; private set; }

        /// <summary>
        /// The Position the Entity will occupy. If not defined, (0.0,0.0,0.0) is assumed
        /// </summary>
        [DataMember(IsRequired=false,Order=3)]
        public Vector3d Position { get; private set; }

        /// <summary>
        /// The Scale the entity will have. If not defined, (1.0,1.0,1.0) is assumed
        /// </summary>
        [DataMember(IsRequired=false,Order=4)]
        public Vector3d Scale { get; private set; }

        /// <summary>
        /// A list of optional Data to feed to Components
        /// </summary>
        [DataMember(IsRequired=false,Order=5)]
        public DataSet DataSet { get; private set; }
    }
}
