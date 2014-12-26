using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameUtilities.Framework.DataContracts
{
    /// <summary>
    /// A data contract defining a Dictionary of Data Entries, that will be fed into each Component attached to a particular entity
    /// </summary>
    [CollectionDataContract(KeyName="Key",ValueName="Value", ItemName="Entry")]
    public class DataSet : Dictionary<string,string>
    {}
}
