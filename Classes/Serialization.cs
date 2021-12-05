using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoreofM_I
{
    internal class Serialization
    {
        public static T DeserializeToObject<T>(string filepath) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return ser.Deserialize(sr) as T;
            }
        }

        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

            using (StreamWriter writer = File.CreateText(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T LoadFromDocumentFormat<T>(T serializableObject, Type[] extraTypes, string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                XmlSerializer xmlSerializer = CreateXmlSerializer(serializableObject, extraTypes);
                serializableObject = (T)xmlSerializer.Deserialize(streamReader);
            }

            return serializableObject;
        }

        public static void SaveToDocumentFormat<T>(T serializableObject, Type[] extraTypes, string path)
        {
            using (StreamWriter textWriter = File.CreateText(path))
            {
                XmlSerializer xmlSerializer = CreateXmlSerializer(serializableObject, extraTypes);
                xmlSerializer.Serialize(textWriter, serializableObject);
            }
        }

        public static XmlSerializer CreateXmlSerializer<T>(T serializableObject, Type[] extraTypes)
        {
            Type ObjectType = serializableObject.GetType();

            XmlSerializer xmlSerializer = null;

            if (extraTypes != null)
                xmlSerializer = new XmlSerializer(ObjectType, extraTypes);
            else
                xmlSerializer = new XmlSerializer(ObjectType);

            return xmlSerializer;
        }
    }
}
