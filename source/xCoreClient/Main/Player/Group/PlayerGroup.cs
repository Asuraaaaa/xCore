using CitizenFX.Core;
using System.Collections.Generic;

namespace xCoreClient.Main.Player.Group
{
    public class PlayerGroup : BaseScript
    {
        private static List<string> groups = new List<string>();

        [EventHandler("xCore:Client:GroupAdded")]
        public  void addPlayerGroup(string gg)
        {
            groups.Add(gg);
        }
        [EventHandler("xCore:Client:GroupRemove")]
        private void removePlayerGroup( string gg)
        {
            groups.Remove(gg);
        }

        public static bool isAtGroup(string group)
        {
            if (groups.Contains(group)) return true;
            return false;
        }

        public static List<string> getPlayerGroups() => groups;
    }
}
