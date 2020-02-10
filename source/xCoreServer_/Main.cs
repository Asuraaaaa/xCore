using CitizenFX.Core;

namespace xCoreServer
{
    class Main : BaseScript
    {
        public static dynamic ML = null;
        public Main()
        {
            ML = Exports["mysql-async"];           
        }

        [EventHandler("onResourceStart")]
        public void resourceLoaded(string resource)
        {
            if(resource == "mysql-async")
            {
                MYSQL.CreateTablesForJobs();
            }
        }
    }
}
