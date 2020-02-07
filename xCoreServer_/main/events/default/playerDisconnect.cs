using CitizenFX.Core;
using xCoreServer.Job;

namespace xCoreServer.main.events
{
    class playerDisconnect : BaseScript
    {
        [EventHandler("playerDropped")]
        public static void playerDisconnectFromGame([FromSource]Player player, string reason)
        {
            var licenseIdentifier = player.Identifiers["steam"];
            PlayerJob job = PlayerJobHolder.getPlayerJob(player);
            if(job != null) MYSQL.execute($"UPDATE playerjob SET name = '{job.getJobName()}',grade = '{job.getJobGrade()}' WHERE steamid = '{licenseIdentifier}'; ");
            Debug.WriteLine($"Player {player.Name} has disconnected! ==================================");
            PlayerJobHolder.removePlayerFromJobList(player);
        }
    }
}
