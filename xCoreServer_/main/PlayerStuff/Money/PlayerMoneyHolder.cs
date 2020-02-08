using CitizenFX.Core;
using System.Collections.Generic;
using xCoreServer.main.functions;

namespace xCoreServer.main.Money
{
    class PlayerMoneyHolder : BaseScript
    {
        public static Dictionary<int, MoneyPlayer> PlayerMoney = new Dictionary<int, MoneyPlayer>();

        public static MoneyPlayer getPlayerMoney(int source)
        {
            MoneyPlayer job;
            PlayerMoney.TryGetValue(source, out job);
            return job;
        }

        public static MoneyPlayer getPlayerMoney(Player player)
        {
            int source = ID.GetPLayerId(player);           
            if (source == -1) return null;
            MoneyPlayer job;
            PlayerMoney.TryGetValue(source, out job);
            return job;
        }

        public static void saveMoneyPlayerToList(int source, MoneyPlayer job)
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

        public static void saveMoneyPlayerToList(Player player, MoneyPlayer job)
        {
            int source = ID.GetPLayerId(player);
            if (source == -1) return;
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
