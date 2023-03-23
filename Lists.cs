using System.Xml.Serialization;

namespace ReadXML
{
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Lists
    {
        List<ListValue> listValues;

        [XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArrayItemAttribute("ListValue", typeof(ListValue), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<ListValue> ListValues
        {
            get { return this.listValues; }
            set { this.listValues = value; }
        }
    }

    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class ListValue
    {
        string name;
        //List<Value> values;

        [XmlAttributeAttribute()]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        //[XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //[XmlArrayItemAttribute("Value", typeof(Value), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        //public List<Value> Values
        //{
        //    get { return this.values; }
        //    set { this.values = value; }
        //}

    }

    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class Value
    {
        string valueId;
        string description;

        [XmlAttributeAttribute()]
        public string ValueId
        {
            get { return this.valueId; }
            set { this.valueId = value;}
        }

        [XmlAttributeAttribute()]
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}
