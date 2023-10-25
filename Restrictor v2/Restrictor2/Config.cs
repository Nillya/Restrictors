using Rocket.API;
using System.Collections.Generic;

namespace ExeDeadZone
{
    public class Config : IRocketPluginConfiguration, IDefaultable
    {
        public void LoadDefaults()
        {
            RestrictedItems = new Dictionary<ushort, ClothSet>
            {
                { 0, new ClothSet(0, 0, 0, 0, 0, 0 , 0) },
            };
        }

        public Dictionary<ushort, ClothSet> RestrictedItems;
    }
}
