using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameUtilities.Services.DataContracts
{
    /// <summary>
    /// Data Contract defining a list of services that the Engine will use
    /// </summary>
    [CollectionDataContract(Name = "ServicesList", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
    public class ServiceDataContract : List<string>
    {
    }
}
