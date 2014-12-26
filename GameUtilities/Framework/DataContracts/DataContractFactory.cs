using System.Xml;
using System.Runtime.Serialization;
using System.IO;

namespace GameUtilities.Framework.DataContracts
{
    /// <summary>
    /// A factory class for deserializing XML into datatypes
    /// </summary>
    public class DataContractFactory
    {
        /// <summary>
        /// Deserializes an Object
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize</typeparam>
        /// <param name="path">The path to the file to deserialize</param>
        /// <returns>an Object (hopefully)</returns>
        public static T DeserializeObject<T>(string path)
        {
            T obj;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            // Create the DataContractSerializer instance.
            DataContractSerializer ser = new DataContractSerializer(typeof(T));

            // Deserialize the data and read it from the instance.
            obj = (T)ser.ReadObject(reader);
            return obj;
        }
    }
}
