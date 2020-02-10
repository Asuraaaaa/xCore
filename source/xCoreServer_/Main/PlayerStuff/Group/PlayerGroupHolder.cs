using CitizenFX.Core;
using System.Collections.Generic;
using xCoreServer.main.functions;

namespace xCoreServer.main.PlayerStuff.groups.events
{
    public class PlayerGroupHolder
    {
        public static Dictionary<int, PlayerGroup> PlayerGroup = new Dictionary<int, PlayerGroup>();

        public static PlayerGroup getPlayerGroup(int source)
        {
            PlayerGroup job;
            PlayerGroup.TryGetValue(source, out job);
            return job;
        }

        public static PlayerGroup getPlayerGroup(Player player)
        {
            int source = ID.GetPLayerId(player);
            if (source == -1) return null;
            PlayerGroup job;
            PlayerGroup.TryGetValue(source, out job);
            return job;
        }

        public static void saveGroupToList(int source, PlayerGroup job)
        {
            if (PlayerGroup.ContainsKey(source))
            {
                PlayerGroup[source] = job;
            }
            else
            {
                PlayerGroup.Add(source, job);
            }
        }

        public static void saveGroupToList(Player player, PlayerGroup job)
        {
            int source = ID.GetPLayerId(player);
            if (source == -1) return;
            if (PlayerGroup.ContainsKey(source))
            {
                PlayerGroup[source] = job;
            }
            else
            {
                PlayerGroup.Add(source, job);
            }
        }

        public static void removePlayerFromGroupList(int source)
        {
            PlayerGroup.Remove(source);
        }

        public static void removePlayerFromGroupList(Player player)
        {
            int source = ID.GetPLayerId(player);
            PlayerGroup.Remove(source);
        }
    }
}
