using System.Xml.Serialization;

namespace ExeRestrctor.Types
{
    public class Item
    {
        [XmlAttribute]
        public ETypeItem Type { get; set; }
        [XmlAttribute]
        public ushort Id { get; set; }
    }
}
