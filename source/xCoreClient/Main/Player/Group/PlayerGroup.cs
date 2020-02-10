using CitizenFX.Core;
using System.Collections.Generic;

namespace xCoreClient.Main.Player.Group
{
    public class PlayerGroup : BaseScript
    {
        private List<string> groups = new List<string>();

        [EventHandler("xCore:Client:GroupAdded")]
        private void addPlayerGroup(string gg)
        {
            groups.Add(gg);
        }
        [EventHandler("xCore:Client:GroupRemove")]
        private void removePlayerGroup( string gg)
        {
            groups.Remove(gg);
        }

        public bool isAtGroup(string group)
        {
            if (groups.Contains(group)) return true;
            return false;
        }

        public List<string> getPlayerGroups() => this.groups;
    }
}
