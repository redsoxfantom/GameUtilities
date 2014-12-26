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
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(T));

            // Deserialize the data and read it from the instance.
            obj = (T)ser.ReadObject(reader);
            fs.Close();
            reader.Close();
            return obj;
        }

        public static void SerializeObject<T>(string path, T obj)
        {
            FileStream fs = new FileStream(path,FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            DataContractSerializer ser = new DataContractSerializer(typeof(T));

            //Serialize the data to a file
            ser.WriteObject(writer, obj);
            writer.Close();
            fs.Close();
        }
    }
}
