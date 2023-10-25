using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExeRestrctor.Types
{
    public class RestrictionGroup
    {
        [XmlAttribute]
        public string Id { get; set; }
        public List<Item> Items { get; set; }
        public ClothSet AllowCloth { get; set; }
    }
}
