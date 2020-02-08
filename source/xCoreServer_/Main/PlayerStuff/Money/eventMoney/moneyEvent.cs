using CitizenFX.Core;
 
namespace xCoreServer.main.Money.eventMoney
{
    class moneyEvent : BaseScript
    {
        [EventHandler("xCore:Server:getPlayerMoney")]
        public void getMoney(int source,string type,dynamic result)
        {
            MoneyPlayer money = PlayerMoneyHolder.getPlayerMoney(source);
            int result_ = int.MinValue;
            var money_      = money.getMoney();
            var bankmoney_  = money.getBankMoney();
            var dirtymoney_ = money.getDirtyMoney();

            if (type.Equals("money"))      result_ = money_;
            if (type.Equals("bankmoney"))  result_ = bankmoney_;
            if (type.Equals("dirtymoney")) result_ = dirtymoney_;

            result(result_);
        }

        [EventHandler("xCore:Server:setMoney")]
        public void setMoney(int source,string type,int money_)
        {
            MoneyPlayer money = PlayerMoneyHolder.getPlayerMoney(source);

            if (type.Equals("money"))      money.setMoney(source, money_);
            if (type.Equals("bankmoney"))  money.setBankMoney(source, money_);
            if (type.Equals("dirtymoney")) money.setDirtyMoney(source,money_);
        }

        [EventHandler("xCore:Server:addMoney")]
        public void addMoney(int source, string type, int money_)
        {
            MoneyPlayer money = PlayerMoneyHolder.getPlayerMoney(source);

            if (type.Equals("money"))      money.addMoney(source, money_);
            if (type.Equals("bankmoney"))  money.addBankMoney(source, money_);
            if (type.Equals("dirtymoney")) money.addDirtyMoney(source, money_);
        }
    }
}
