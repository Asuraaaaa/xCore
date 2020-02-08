using CitizenFX.Core;
using xCoreServer.Job;
using xCoreServer.main.Money;

namespace xCoreServer.main.events
{
    class playerDisconnect : BaseScript
    {
        [EventHandler("playerDropped")]
        public static void playerDisconnectFromGame([FromSource]Player player, string reason)
        {
            var licenseIdentifier = player.Identifiers["steam"];
            //=====================
            PlayerJob job = PlayerJobHolder.getPlayerJob(player);
            if(job != null) MYSQL.execute($"UPDATE playerjob " +
                                          $"SET name = '{job.getJobName()}'," +
                                          $"grade = '{job.getJobGrade()}' " +
                                          $"WHERE steamid = '{licenseIdentifier}'; ");
            PlayerJobHolder.removePlayerFromJobList(player);
            //=====================
            MoneyPlayer money = PlayerMoneyHolder.getPlayerMoney(player);
            if (money != null) MYSQL.execute($"UPDATE playermoney " +
                                             $"SET money = '{money.getMoney()}'," +
                                             $"bank = '{money.getBankMoney()}'," +
                                             $"dirty_money='{money.getDirtyMoney()}'" +
                                             $" WHERE steamid = '{licenseIdentifier}'; ");
            PlayerMoneyHolder.removePlayerFromMoneyList(player);
            //=====================

            //=====================

            //=====================

            //=====================
            Debug.WriteLine($"Player {player.Name} has disconnected! ================================== :(");                     
        }
    }
}
