using GameUtilities.Services.DataContracts;
using System.Runtime.Serialization;

namespace GameUtilities.Framework.Engine.DataContracts
{
    /// <summary>
    /// Data contract for Engine Config files 
    /// </summary>
    [DataContract(Name="EngineConfig",Namespace="")]
    public class EngineConfigDataContract
    {
        /// <summary>
        /// The list of Services that this Engine supports
        /// </summary>
        [DataMember(IsRequired=true,Order=0)]
        public ServiceDataContract Services { get; private set;}
    }
}
