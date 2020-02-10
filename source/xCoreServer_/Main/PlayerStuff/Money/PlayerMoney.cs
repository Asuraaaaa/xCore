using CitizenFX.Core;
 
namespace xCoreServer.main.Money
{
    public class PlayerMoney : BaseScript
    {
        private int money_ = 0;
        private int bank_ = 0;
        private int dirtyMoney_ = 0;
        private Player player_;

        public void setPlayer(Player player) => this.player_ = player;
        public Player getPlayer() => this.player_;

        public void setMoney(int result)
        {
            this.money_ = result;
            Player player = getPlayer();
            player.TriggerEvent("xCore:Client:MoneyUpdated", "money", result);
        }
        public void setBankMoney(int result)
        {
            this.bank_ = result;
            Player player = getPlayer();
            player.TriggerEvent("xCore:Client:MoneyUpdated", "bankmoney", result);
        }
        public void setDirtyMoney(int result)
        {
            this.dirtyMoney_ = result;
            Player player = getPlayer();
            player.TriggerEvent("xCore:Client:MoneyUpdated", "dirtymoney", result);
        }


        public int getMoney() => this.money_; 
        public int getBankMoney() => this.bank_;
        public int getDirtyMoney() => this.dirtyMoney_;


        public void addMoney(int result) => setMoney(getMoney() + result);
        public void addBankMoney(int result) => setMoney(getMoney() + result);
        public void addDirtyMoney(int result) => setMoney(getMoney() + result);
    }
}
