using GameUtilities.Framework.DataContracts;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace GameUtilitiesRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet set = new DataSet();
            set.Add("KEY", "VALUE");
            set.Add("KEY2", "VALUE2");

            WriteObject("TEST.XML", set);
        }

        public static void WriteObject(string path, DataSet set)
        {
            FileStream fs = new FileStream(path,FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            DataContractSerializer ser = new DataContractSerializer(typeof(DataSet));
            ser.WriteObject(writer, set);
            Console.WriteLine("Finished writing object.");
            writer.Close();
            fs.Close();
        }

    }
}
