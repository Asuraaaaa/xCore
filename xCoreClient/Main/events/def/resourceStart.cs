using CitizenFX.Core;
using xCoreClient.main.Player;

namespace xCoreClient.Main.events.def
{
    class resourceStart : BaseScript
    {
        [EventHandler("onClientResourceStart")]
        public void onClientResourceStart(string resource)
        {
            if (resource.Equals("xCore"))
            {
                TriggerServerEvent("xCore:server:loadPlayerJob", ID.playerID());
                TriggerServerEvent("xCore:server:loadPlayerMoney", ID.playerID());
            }
        }
    }
}
