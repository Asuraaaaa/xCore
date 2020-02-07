using CitizenFX.Core;
using System.Collections.Generic;

namespace xCoreServer.Job
{
    class PlayerJobHolder : BaseScript
    {
        public static Dictionary<int, PlayerJob> PlayersJobs = new Dictionary<int, PlayerJob>();

        public static PlayerJob getPlayerJob(int source)
        {
            PlayerJob job;
            PlayersJobs.TryGetValue(source, out job);
            return job;
        }

        public static PlayerJob getPlayerJob(Player player)
        {
            int source = GetPLayerId(player);
            if (source == -1) return null;
            PlayerJob job;
            PlayersJobs.TryGetValue(source, out job);
            return job;
        }

        public static void savePlayerToList(int source, PlayerJob job)
        {
            if (PlayersJobs.ContainsKey(source))
            {
                PlayersJobs[source] = job;
            }
            else
            {
                PlayersJobs.Add(source, job);
            }
        }

        public static void savePlayerToList(Player player, PlayerJob job)
        {
            int source = GetPLayerId(player);
            if (source == -1) return;
            if (PlayersJobs.ContainsKey(source))
            {
                PlayersJobs[source] = job;
            }
            else
            {
                PlayersJobs.Add(source, job);
            }
        }

        public static void removePlayerFromJobList(int source)
        {
            PlayersJobs.Remove(source);
        }

        public static void removePlayerFromJobList(Player player)
        {
            int source = GetPLayerId(player);
            PlayersJobs.Remove(source);
        }

        public static int GetPLayerId(Player player)
        {
            int id = 0;
            foreach (Player pp in new PlayerList())
            {
                id++;
                if (pp == player)
                {
                    return id;
                }
            }
            return -1;
        }
    }
}
