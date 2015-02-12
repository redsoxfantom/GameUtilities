using GameUtilities.Services.DataContracts;
using System.Collections.Generic;
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
        [DataMember(Name="ServicesList", IsRequired=true,Order=0)]
        public List<string> ServicesList { get; private set; }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="mServices">A list of services that this engine supports</param>
        public EngineConfigDataContract(List<string> mServices)
        {
            ServicesList = mServices;
        }
    }
}
