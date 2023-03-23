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
        public static T Load<T>(string xmlFile)
        {
            T result = default(T);

            if (string.IsNullOrEmpty(xmlFile))
                throw new ArgumentNullException("xmlFile", "Xml File can't be null or Empty.");

            try
            {
                using (TextReader reader = new StringReader(xmlFile))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    result = (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Reading File Error: {0} [{1}]", ex.Message, ex.InnerException.Message), ex);
            }

            return result != null ? result : Activator.CreateInstance<T>();
        }
    }
}
