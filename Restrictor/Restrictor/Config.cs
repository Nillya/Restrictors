using ExeRestrctor.Types;
using Rocket.API;
using SDG.Unturned;
using System.Collections.Generic;
using System.Threading.Tasks;
using Item = ExeRestrctor.Types.Item;

namespace ExeRestrctor
{
    public class Config : IRocketPluginConfiguration
    {
        public List<RestrictionGroup> RestrictionGroups;
        public ushort RestrictedItemId;

        public IEnumerable<object> RestrictedItems { get; internal set; }

        public void LoadDefaults()
        {
            RestrictionGroups = new List<RestrictionGroup>
            {
                new RestrictionGroup
                {
                    Id = "default",
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Type = ETypeItem.Equipment,
                            Id = 519
                        }
                    },
                    AllowCloth = new ClothSet
                    {
                        Hat = 0,
                        Glasses = 0,
                        Vest = 0,
                        Shirt = 0,
                        Pants = 0,
                        Backpack = 0,
                        Mask = 0
                    }
                }
            };
        }
    }
}
