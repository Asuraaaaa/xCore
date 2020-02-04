using CitizenFX.Core;
using System.Collections.Generic;

namespace xCoreServer.JobInit
{
    class LoadJob : BaseScript
    {
        public static void loadPlayerJob(int source)
        {
            Player player = new PlayerList()[source];
            string job = "Bez práce";
            string grade = "ahjo";

            var licenseIdentifier = player.Identifiers["steam"];
            MYSQL.FetchAll($"SELECT * FROM playerjob WHERE steamid = '{licenseIdentifier}'", null, (List<dynamic> list) =>
            {
                int count = (list == null) ? 0 : list.Count;
                if (count == 0)
                {
                    MYSQL.execute($"INSERT INTO playerjob (name,grade,steamid) VALUES ('{job}','{grade}','{licenseIdentifier}');");
                    Debug.WriteLine("Zapisuju nového hráče do tabulky 'PlayerJob'");
                    player.TriggerEvent("xCore:client:LoadJob", job, grade);
                }
                else
                {
                    player.TriggerEvent("xCore:client:LoadJob", list[0].name, list[0].grade);
                }
            });           
        }
    }
}
