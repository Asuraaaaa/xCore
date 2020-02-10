using CitizenFX.Core;
using System.Collections.Generic;

namespace xCoreServer.main.PlayerStuff.groups
{
    public class PlayerGroup : BaseScript
    {
        private List<string> playerGroup = new List<string>();
        private Player player_;
        public List<string> playerGroups() => this.playerGroup;

        public void setPlayer(Player player) => this.player_ = player;
        public Player getPlayer() => this.player_;

        public void add(string group)
        {
            if (!isAtGroup(group))
            {
                Player player = getPlayer();
                playerGroup.Add(group);
                Debug.WriteLine($"Puting player: {player.Name} into group: {group}");
                player.TriggerEvent("xCore:Client:GroupAdded", group);
            }
        }

        public void remove(string group)
        {
            if (isAtGroup(group))
            {
                Player player = getPlayer();
                playerGroup.Remove(group);
                Debug.WriteLine($"Removing player: {player.Name} from group: {group}");
                player.TriggerEvent("xCore:Client:GroupRemove", group);
            }
        }

        public bool isAtGroup(string group)
        {
            if (playerGroup.Contains(group)) return true;
            return false;
        }
        public bool exists(string group)
        {
            if (playerGroup.Contains(group)) return true;
            return false;
        }
    }
}
