using CitizenFX.Core;
using System;
using xCoreServer.JobInit;
using xCoreServer.main.events;

namespace xCoreServer
{
    class Main : BaseScript
    {
        public static dynamic ML;
        public Main()
        {
            ML = Exports["mysql-async"];

            EventHandlers["xCore:server:loadPlayerJob"] += new Action<int>(LoadJob.loadPlayerJob);
            EventHandlers["playerConnecting"]           += new Action<Player, string, dynamic, dynamic>(playerConnect.OnPlayerConnecting);         
        }
    }
}
