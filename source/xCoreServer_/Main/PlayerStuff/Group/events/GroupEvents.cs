using CitizenFX.Core;
using xCoreServer.main.PlayerStuff.groups;
using xCoreServer.main.PlayerStuff.groups.events;

namespace xCoreServer.main.PlayerStuff.Group.events
{
    class GroupEvents : BaseScript
    {
        [EventHandler("xCore:Server:addPlayerGroup")]
        void addPlayerGroup(int source,string group)
        {
            PlayerGroup gp = PlayerGroupHolder.getPlayerGroup(source);
            gp.add(group);
        }

        [EventHandler("xCore:Server:removePlayerGroup")]
        void removePlayerGroup(int source,string group)
        {
            PlayerGroup gp = PlayerGroupHolder.getPlayerGroup(source);
            gp.remove(group);
        }
    }
}
