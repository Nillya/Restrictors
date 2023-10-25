using ExeRestrctor.Types;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Linq;
using UnityEngine;

namespace ExeRestrctor
{
    class PlayerComponent : UnturnedPlayerComponent
    {
        private DateTime _lastCalled = DateTime.Now;

        protected override void Load()
        {
            Player.Player.equipment.onEquipRequested += OnEquipRequested;
        }

        protected override void Unload()
        {
            Player.Player.equipment.onEquipRequested -= OnEquipRequested;
        }

        private void OnPlayerUpdate(UnturnedPlayer player)
        {
            if ((DateTime.Now - _lastCalled).TotalSeconds >= 0.1)
            {
                if (player.HasPermission("restrctor.bypass"))
                    return;

                CheckClothing(player, "Hat", player.Player.clothing.hat);
                CheckClothing(player, "Glasses", player.Player.clothing.glasses);
                CheckClothing(player, "Mask", player.Player.clothing.mask);
                CheckClothing(player, "Shirt", player.Player.clothing.shirt);
                CheckClothing(player, "Vest", player.Player.clothing.vest);
                CheckClothing(player, "Pants", player.Player.clothing.pants);
                CheckClothing(player, "Backpack", player.Player.clothing.backpack);

                _lastCalled = DateTime.Now;
            }
        }

        private void OnEquipRequested(PlayerEquipment equipment, ItemJar jar, ItemAsset asset, ref bool shouldAllow)
        {
            try
            {
                if (Player.HasPermission("exerestrctor.bypass"))
                    return;

                var allowed = false;

                foreach (var restrictedItem in Plugin.Instance.Configuration.Instance.RestrictedItems)
                {
                    if (restrictedItem is Types.Item item && item.Type == ETypeItem.Equipment && item.Id == asset.id)
                    {
                        allowed = true;
                        break;
                    }
                }

                if (!allowed)
                {
                    UnturnedChat.Say(Player, Plugin.Instance.Translate("cant_equipment"), Color.red);
                    shouldAllow = false;
                }
            }
            catch (Exception ex)
            {
                Rocket.Core.Logging.Logger.LogException(ex, "Exception in OnEquipRequested()");
            }
        }

        private void CheckClothing(UnturnedPlayer player, string clothingType, ushort itemId)
        {
            if (itemId != 0 && !IsAllowedClothItem(clothingType, itemId))
            {
                switch (clothingType)
                {
                    case "Hat":
                        Player.Player.clothing.askWearHat(0, 0, new byte[0], true);
                        break;
                    case "Glasses":
                        Player.Player.clothing.askWearGlasses(0, 0, new byte[0], true);
                        break;
                    case "Mask":
                        Player.Player.clothing.askWearMask(0, 0, new byte[0], true);
                        break;
                    case "Shirt":
                        Player.Player.clothing.askWearShirt(0, 0, new byte[0], true);
                        break;
                    case "Vest":
                        Player.Player.clothing.askWearVest(0, 0, new byte[0], true);
                        break;
                    case "Pants":
                        Player.Player.clothing.askWearPants(0, 0, new byte[0], true);
                        break;
                    case "Backpack":
                        Player.Player.clothing.askWearBackpack(0, 0, new byte[0], true);
                        break;
                }

                UnturnedChat.Say(Player, Plugin.Instance.Translate("cant_cloth"), Color.red);
            }
        }

        private bool IsAllowedClothItem(string type, ushort itemId)
        {
            var restrictionGroup = GetPlayerRestrictionGroup(Player);
            if (restrictionGroup == null)
                return false;

            var clothSet = restrictionGroup.AllowCloth;

            switch (type)
            {
                case "Hat":
                    return itemId == clothSet.Hat;
                case "Glasses":
                    return itemId == clothSet.Glasses;
                case "Vest":
                    return itemId == clothSet.Vest;
                case "Shirt":
                    return itemId == clothSet.Shirt;
                case "Pants":
                    return itemId == clothSet.Pants;
                case "Backpack":
                    return itemId == clothSet.Backpack;
                case "Mask":
                    return itemId == clothSet.Mask;
                default:
                    return false;
            }
        }


        private RestrictionGroup GetPlayerRestrictionGroup(UnturnedPlayer player)
        {
            RestrictionGroup group = null;

            foreach (var restGroup in Plugin.Instance.Configuration.Instance.RestrictionGroups.Where(x => x.Id.ToLower() != "default"))
            {
                foreach (var permGroup in R.Permissions.GetGroups(player, false))
                {
                    if (restGroup.Id.ToLower() == permGroup.Id.ToLower())
                    {
                        group = restGroup;
                        return group;
                    }
                }
            }

            return group;
        }
    }
}
