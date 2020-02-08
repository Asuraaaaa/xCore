using CitizenFX.Core;
 
namespace xCoreServer.main.functions
{
    class ID : BaseScript
    {
        public static int GetPLayerId(Player player)
        {
            int id = 0;
            foreach (Player pp in new PlayerList())
            {
                id++;
                if (pp == player)
                {
                    return id;
                }
            }
            return -1;
        }
    }
}
