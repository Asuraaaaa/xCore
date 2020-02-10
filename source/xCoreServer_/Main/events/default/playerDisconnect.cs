using CitizenFX.Core;
using System.Collections.Generic;
using System.Text;
using xCoreServer.Job;
using xCoreServer.main.Money;
using xCoreServer.main.PlayerStuff.groups;
using xCoreServer.main.PlayerStuff.groups.events;

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
            if (job != null)
            {
                MYSQL.execute($"UPDATE playerjob " +
                              $"SET name = '{job.getJobName()}'," +
                              $"grade = '{job.getJobGrade()}' " +
                              $"WHERE steamid = '{licenseIdentifier}'; ");

                PlayerJobHolder.removePlayerFromJobList(player);
            }
            //=====================
            PlayerMoney money = PlayerMoneyHolder.getPlayerMoney(player);
            if (money != null)
            {
                MYSQL.execute($"UPDATE playermoney " +
                              $"SET money = '{money.getMoney()}'," +
                              $"bank = '{money.getBankMoney()}'," +
                              $"dirty_money='{money.getDirtyMoney()}'" +
                              $"WHERE steamid = '{licenseIdentifier}'; ");

                PlayerMoneyHolder.removePlayerFromMoneyList(player);
            }
            //=====================
            PlayerGroup group = PlayerGroupHolder.getPlayerGroup(player);
            if (group != null)
            {
                List<string> gp = group.playerGroups();
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < gp.Count; i++)
                    sb.Append($"('{licenseIdentifier}', '{gp[i]}'),");


                MYSQL.execute($"DELETE FROM `groupusers` WHERE steamid = '{licenseIdentifier}';" +
                              $"INSERT INTO `groupusers` (`steamid`, `group`) VALUES {sb.ToString().Remove(sb.Length - 1)}");


                PlayerGroupHolder.removePlayerFromGroupList(player);
            }
            //=====================

            //=====================

            //=====================
            Debug.WriteLine($"Player {player.Name} has disconnected! ================================== :(");
        }
    }
}
