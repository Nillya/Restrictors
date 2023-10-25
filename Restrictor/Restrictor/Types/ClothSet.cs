using System;
using System.Xml.Serialization;

namespace ExeRestrctor.Types
{
    public class ClothSet
    {
        [XmlAttribute]
        public ushort Hat { get; set; }

        [XmlAttribute]
        public ushort Glasses { get; set; }

        [XmlAttribute]
        public ushort Vest { get; set; }

        [XmlAttribute]
        public ushort Shirt { get; set; }

        [XmlAttribute]
        public ushort Pants { get; set; }

        [XmlAttribute]
        public ushort Backpack { get; set; }

        [XmlAttribute]
        public ushort Mask { get; set; }
    }
}
