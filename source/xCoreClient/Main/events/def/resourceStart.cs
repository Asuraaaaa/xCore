using CitizenFX.Core;
using CitizenFX.Core.Native;
using xCoreClient.main.Player;

namespace xCoreClient.Main.events.def
{
    class resourceStart : BaseScript
    {
        [EventHandler("onClientResourceStart")]
        public void onClientResourceStart(string resource)
        {
            if (resource.Equals(API.GetCurrentResourceName()))
            {
                TriggerServerEvent("xCore:server:loadPlayerJob",    ID.playerID());
                TriggerServerEvent("xCore:server:loadPlayerMoney",  ID.playerID());
                TriggerServerEvent("xCore:server:loadPlayerGroups", ID.playerID());
            }
        }
    }
}
