using CitizenFX.Core;
 
namespace xCoreServer.main.Money
{
    class PlayerMoney : BaseScript
    {
        private int money_ = 0;
        private int bank_ = 0;
        private int dirtyMoney_ = 0;

        public void setMoney(int source,int result)
        {
            this.money_ = result;
            Player player = new PlayerList()[source];
            player.TriggerEvent("xCore:Client:MoneyUpdated", "money", result);
        }
        public void setBankMoney(int source, int result)
        {
            this.bank_ = result;
            Player player = new PlayerList()[source];
            player.TriggerEvent("xCore:Client:MoneyUpdated", "bankmoney", result);
        }
        public void setDirtyMoney(int source, int result)
        {
            this.dirtyMoney_ = result;
            Player player = new PlayerList()[source];
            player.TriggerEvent("xCore:Client:MoneyUpdated", "dirtymoney", result);
        }


        public int getMoney() => this.money_; 
        public int getBankMoney() => this.bank_;
        public int getDirtyMoney() => this.dirtyMoney_;


        public void addMoney(int source, int result) => setMoney(source, getMoney() + result);
        public void addBankMoney(int source, int result) => setMoney(source, getMoney() + result);
        public void addDirtyMoney(int source, int result) => setMoney(source, getMoney() + result);
    }
}
