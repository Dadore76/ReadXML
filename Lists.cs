using System.Xml.Serialization;

namespace ReadXML
{
    [XmlRoot("ListValues")]
    public class Lists
    {
        List<ListValue> listValues = new();

        [XmlElement("ListValue")]
        public List<ListValue> ListValues
        {
            get { return this.listValues; }
            set { this.listValues = value; }
        }
    }

    public class ListValue
    {
        string name = string.Empty;
        List<Value> values = new();

        [XmlAttribute("Name")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [XmlElement("Value")]
        public List<Value> Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

    }

    public class Value
    {
        string valueID = string.Empty;
        string description = string.Empty;

        [XmlAttribute("ValueId")]
        public string ValueID
        {
            get { return this.valueID; }
            set { this.valueID = value;}
        }

        [XmlAttribute("Description")]
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}
