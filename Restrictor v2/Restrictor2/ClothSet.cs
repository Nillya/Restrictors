using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ExeDeadZone {
    public class ClothSet {
        [XmlAttribute] public ushort Hat;
        [XmlAttribute] public ushort Mask;
        [XmlAttribute] public ushort Glasses;
        [XmlAttribute] public ushort Shirt;
        [XmlAttribute] public ushort Vest;
        [XmlAttribute] public ushort Pants;
        [XmlAttribute] public ushort BackPack;
        public ClothSet(ushort _Hat, ushort _Shirt, ushort _Vest, ushort _Pants, ushort _BackPack, ushort _Mask, ushort _Glasses) {
            Hat = _Hat;
            Mask = _Mask;
            Glasses = _Glasses;
            Shirt = _Shirt;
            Vest = _Vest;
            Pants = _Pants;
            BackPack = _BackPack;
        }
        public ClothSet() { }
    }
}
