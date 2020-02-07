using CitizenFX.Core;
using System;
using System.Threading;
using xCoreServer.Job;
using xCoreServer.JobInit;
using xCoreServer.main.events;

namespace xCoreServer
{
    class Main : BaseScript
    {
        public static dynamic ML = null;
        public Main()
        {
            ML = Exports["mysql-async"];
            MYSQL.CreateTablesForJobs();
            int id = 0;
            foreach (Player player in new PlayerList())
            {
                id++;
                if (player == null) continue;
                LoadJob.loadPlayerJob(id);
            }
        }
    }
}
