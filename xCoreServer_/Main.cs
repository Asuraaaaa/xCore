using CitizenFX.Core;

namespace xCoreServer
{
    class Main : BaseScript
    {
        public static dynamic ML = null;
        public Main()
        {
            ML = Exports["mysql-async"];
            MYSQL.CreateTablesForJobs();
        }
    }
}
