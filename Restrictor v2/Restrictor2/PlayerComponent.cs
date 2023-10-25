using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace ExeDeadZone
{
    public class PlayerComponent : UnturnedPlayerComponent
    {
        protected override void Load()
        {
            Player.Player.inventory.onInventoryStateUpdated += OnInventoryStateUpdated;
        }

        protected override void Unload()
        {
            Player.Player.inventory.onInventoryStateUpdated -= OnInventoryStateUpdated;
        }

        private void OnInventoryStateUpdated()
        {
            if (Player.Player.equipment.asset != null &&
                Plugin.Instance.Configuration.Instance.RestrictedItems.ContainsKey(Player.Player.equipment.asset.id))
            {
                var cloth = Plugin.Instance.Configuration.Instance.RestrictedItems[Player.Player.equipment.asset.id];
                var plcloth = Player.Player.clothing;

                if (plcloth.hat != cloth.Hat || plcloth.shirt != cloth.Shirt ||
                    plcloth.vest != cloth.Vest || plcloth.pants != cloth.Pants ||
                    plcloth.backpack != cloth.BackPack)
                {
                    Player.Player.equipment.dequip();
                }
            }
        }
    }
}
