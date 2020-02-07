using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Collections.Generic;
using xCoreServer;

namespace xMenuServer
{
    public class main : BaseScript
    {
        public main()
        {
            Debug.WriteLine(" ========================================");
        }


        [EventHandler("xMenu:server:setJobCommand")]
        public void setJobCommand(int id, string name, int grade, dynamic result)
        {
            MYSQL.FetchAll($"SELECT * FROM jobgrades WHERE name = '{name}' AND grade ='{grade}'", null, (List<dynamic> list) =>
            {
                if (list == null)
                {
                    result(false);
                }
                else
                {
                    Debug.WriteLine($"{ list[0].name},{list[0].position}");
                    TriggerEvent("xCore:Server:setJob", id, list[0].name, list[0].position);
                    result(true);
                }
            });
        }
    }
}
