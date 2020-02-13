using CitizenFX.Core;
using System;
using System.Threading.Tasks;
using xCoreClient.main.Player;

namespace xCoreClient.Main.Player.money
{
    public class PlayerMoney : BaseScript
    {
        private int dirtyMoney;
        private int bankMoney;
        private int money_;

        [EventHandler("xCore:Client:MoneyUpdated")]
        private void playerUpdateMoney(string type,int money)
        {
            if (type == "dirtymoney") this.bankMoney  = money;
            if (type == "bankmoney")  this.dirtyMoney = money;
            if (type == "money")      this.money_     = money;
        }

        public int getDirtyMoney() => this.dirtyMoney;
        public int getBankMoney() => this.bankMoney;
        public int getMoney() => this.money_;
    }
}
