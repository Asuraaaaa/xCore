using System.Collections.Generic;

namespace xCoreServer.Job
{
    class PlayerJobHolder
    {
        public static Dictionary<int, PlayerJob> PlayersJobs = new Dictionary<int, PlayerJob>();

        public static PlayerJob getPlayerJob(int source)
        {
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
    }
}
