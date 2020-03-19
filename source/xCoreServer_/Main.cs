using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using xCoreServer.Job;
using xCoreServer.main.Money;
using xCoreServer.main.PlayerStuff.groups.events;

namespace xCoreServer
{
    class Main : BaseScript
    {
        public static dynamic ML = null;
        public Main()
        {
            ML = Exports["mysql-async"];
            //===================================//
            //            MoneySystem            //
            //===================================//
            Exports.Add("playerMoneyHolder", new Func<int,dynamic> (PlayerMoneyHolder.getPlayerMoney));
            //===================================//
            //            JobSystem              //
            //===================================//
            Exports.Add("playerJobHolder", new Func<int, dynamic>  (PlayerJobHolder.getPlayerJob));
            //===================================//
            //            GroupSystem            //
            //===================================//
            Exports.Add("playerGroupHolder", new Func<int, dynamic>(PlayerGroupHolder.getPlayerGroup));
        }

        [EventHandler("onResourceStart")]
        public void resourceLoaded(string resource)
        {
            if(resource == "mysql-async")
            {
                Debug.WriteLine("Creating tables maybe ?");
                MYSQL.CreateTablesForJobs();
            }
        }
    }
}
