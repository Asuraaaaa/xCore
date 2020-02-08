using CitizenFX.Core;
using System;
using System.Collections.Generic;
 
namespace xCoreServer
{
    public class MYSQL : BaseScript
    {
        public static void CreateTablesForJobs()
        {
            execute("CREATE TABLE IF NOT EXISTS jobgrades (" +
             "id int(11) NOT NULL AUTO_INCREMENT," +
             "name varchar(64) NOT NULL," +
             "position varchar(64) NOT NULL," +
             "payment int(11) NOT NULL," +
             "grade int(11) NOT NULL," +
             "female_skin text NOT NULL," +
             "male_skin text NOT NULL," +
             "PRIMARY KEY (id)) ENGINE = InnoDB;");

            execute("CREATE TABLE IF NOT EXISTS playerjob (id INT NOT NULL AUTO_INCREMENT," +
                " name VARCHAR(250) NOT NULL," +
                " grade VARCHAR(32) NOT NULL," +
                " steamid VARCHAR(50) NOT NULL," +
                " PRIMARY KEY(id)) ENGINE = InnoDB; ");

            execute("CREATE TABLE playermoney " +
                "( id INT NOT NULL AUTO_INCREMENT ," +
                " steamid VARCHAR(50) NOT NULL ," +
                " money INT NOT NULL ," +
                " bank INT NOT NULL ," +
                " dirty_money INT NOT NULL ," +
                " PRIMARY KEY (id)) ENGINE = InnoDB;");
        }

        public static void FetchAll(string query, Dictionary<string, object> pars, Action<List<dynamic>> action) => Main.ML.mysql_fetch_all(query, pars, action);
        public static void execute(string query) => Main.ML.mysql_execute(query);
    }
}
