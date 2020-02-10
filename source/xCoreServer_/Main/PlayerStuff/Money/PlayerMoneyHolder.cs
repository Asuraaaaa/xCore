using CitizenFX.Core;
using System.Collections.Generic;
using xCoreServer.main.functions;

namespace xCoreServer.main.Money
{
    public class PlayerMoneyHolder : BaseScript
    {
        public static Dictionary<int, PlayerMoney> PlayerMoney = new Dictionary<int, PlayerMoney>();

        public static PlayerMoney getPlayerMoney(int source)
        {
            PlayerMoney job;
            PlayerMoney.TryGetValue(source, out job);
            return job;
        }

        public static PlayerMoney getPlayerMoney(Player player)
        {
            int source = ID.GetPLayerId(player);           
            PlayerMoney job;
            PlayerMoney.TryGetValue(source, out job);
            return job;
        }

        public static void saveMoneyPlayerToList(int source, PlayerMoney job)
        {
            if (PlayerMoney.ContainsKey(source))
            {
                PlayerMoney[source] = job;
            }
            else
            {
                PlayerMoney.Add(source, job);
            }
        }

        public static void saveMoneyPlayerToList(Player player, PlayerMoney job)
        {
            int source = ID.GetPLayerId(player);
            if (PlayerMoney.ContainsKey(source))
            {
                PlayerMoney[source] = job;
            }
            else
            {
                PlayerMoney.Add(source, job);
            }
        }

        public static void removePlayerFromMoneyList(int source)
        {
            PlayerMoney.Remove(source);
        }

        public static void removePlayerFromMoneyList(Player player)
        {
            int source = ID.GetPLayerId(player);
            PlayerMoney.Remove(source);
        }  
    }
}
