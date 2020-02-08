using CitizenFX.Core;
using xCoreClient.main.Player;

namespace xCoreClient.Main.events.def
{
    class playerSpawn : BaseScript
    {
        [EventHandler("playerSpawned")]
        public static void playerSpawned(dynamic SpawnInfo)
        {        
            TriggerServerEvent("xCore:server:loadPlayerJob",   ID.playerID());
            TriggerServerEvent("xCore:server:loadPlayerMoney", ID.playerID());
        }
    }
}
