﻿using CitizenFX.Core;
 
namespace xCoreServer.main.Money.eventMoney
{
    class moneyEvent : BaseScript
    {
        [EventHandler("xCore:Server:getPlayerMoney")]
        public void getMoney(int source,string type,dynamic result)
        {
            PlayerMoney money = PlayerMoneyHolder.getPlayerMoney(source);
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
            PlayerMoney money = PlayerMoneyHolder.getPlayerMoney(source);

            if (type.Equals("money"))      money.setMoney(money_);
            if (type.Equals("bankmoney"))  money.setBankMoney(money_);
            if (type.Equals("dirtymoney")) money.setDirtyMoney(money_);
        }

        [EventHandler("xCore:Server:addMoney")]
        public void addMoney(int source, string type, int money_)
        {
            PlayerMoney money = PlayerMoneyHolder.getPlayerMoney(source);

            if (type.Equals("money"))      money.addMoney(money_);
            if (type.Equals("bankmoney"))  money.addBankMoney(money_);
            if (type.Equals("dirtymoney")) money.addDirtyMoney(money_);
        }
    }
}
