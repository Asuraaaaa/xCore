using CitizenFX.Core;
using System.Collections.Generic;

namespace xCoreServer.main.PlayerStuff.groups.events
{
    public class PlayerGroupLoader : BaseScript
    {
        [EventHandler("xCore:server:loadPlayerGroups")]
        public static void loadPlayerGroup(int source)
        {
            Player player = new PlayerList()[source];
            var licenseIdentifier = player.Identifiers["steam"];
            MYSQL.FetchAll($"SELECT * FROM groupusers WHERE steamid = '{licenseIdentifier}'", null, (List<dynamic> list) =>
            {
                PlayerGroup pGroup = new PlayerGroup();
                pGroup.setPlayer(player);
                int count = (list == null) ? 0 : list.Count;
                if (count != 0)
                {
                    for(int i = 0; i < count; i ++) pGroup.add(list[i].group);
                }                             
                PlayerGroupHolder.saveGroupToList(player, pGroup);
            });
        }
    }
}
