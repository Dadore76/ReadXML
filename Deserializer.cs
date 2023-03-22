using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReadXML
{
    static class Deserializer
    {
        public static T XmlDeserializeFromString<T>(string xmlFile)
        {
            T result;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            
            using (StreamReader reader = new StreamReader(xmlFile, Encoding.UTF8, true))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
