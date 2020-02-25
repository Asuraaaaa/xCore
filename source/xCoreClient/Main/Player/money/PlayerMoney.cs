using CitizenFX.Core;
using System;
using System.Threading.Tasks;
using xCoreClient.main.Player;

namespace xCoreClient.Main.Player.money
{
    public class PlayerMoney : BaseScript
    {
        private static int dirtyMoney;
        private static int bankMoney;
        private static int money_;

        [EventHandler("xCore:Client:MoneyUpdated")]
        private void playerUpdateMoney(string type,int money)
        {
            if (type == "dirtymoney") dirtyMoney = money;
            if (type == "bankmoney")  bankMoney = money;
            if (type == "money")      money_     = money;
        }

        public static int getDirtyMoney() => dirtyMoney;
        public static int getBankMoney() => bankMoney;
        public static int getMoney() => money_;
    }
}
