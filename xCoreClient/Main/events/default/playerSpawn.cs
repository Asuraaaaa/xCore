using CitizenFX.Core;
using xCoreClient.main.Player;

namespace xCoreClient.events
{
    class playerSpawn : BaseScript
    {
        public static void playerSpawned(dynamic SpawnInfo)
        {        
            TriggerServerEvent("xCore:server:loadPlayerJob", ID.playerID());
        }
    }
}
