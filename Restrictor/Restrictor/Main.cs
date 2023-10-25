using ExeRestrctor.Types;
using Rocket.Core;
using Rocket.Unturned.Player;
using System.Linq;

namespace ExeRestrctor
{
    public static class Main
    {
        public static bool TryGetRestrictionGroup(this UnturnedPlayer uPlayer, out RestrictionGroup group)
        {
            group = null;

            foreach (var restGroup in Plugin.Instance.Configuration.Instance.RestrictionGroups.Where(x => x.Id.ToLower() != "default"))
            {
                foreach (var permGroup in R.Permissions.GetGroups(uPlayer, false))
                {
                    if (restGroup.Id.ToLower() == permGroup.Id.ToLower())
                    {
                        group = restGroup;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
