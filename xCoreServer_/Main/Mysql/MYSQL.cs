using CitizenFX.Core;
using System;
using System.Collections.Generic;

namespace xCoreServer
{
    class MYSQL : BaseScript
    {
        public static void FetchAll(string query, Dictionary<string, object> pars, Action<List<dynamic>> action) => Main.ML.mysql_fetch_all(query, pars, action);
        public static void execute(string query) => Main.ML.mysql_execute(query);
    }
}
