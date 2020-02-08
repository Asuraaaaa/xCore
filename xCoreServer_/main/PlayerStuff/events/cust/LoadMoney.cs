using CitizenFX.Core;
using System.Collections.Generic;
using xCoreServer.main.Money;
  
namespace xCoreServer.main.events
{
    class LoadMoney : BaseScript
    {
        [EventHandler("xCore:server:loadPlayerMoney")]
        public void loadPlayerMoney(int id)
        {
            Player player = new PlayerList()[id];      
            var licenseIdentifier = player.Identifiers["steam"];
            MYSQL.FetchAll($"SELECT * FROM playermoney WHERE steamid = '{licenseIdentifier}'", null, (List<dynamic> list) =>
            {
                Debug.WriteLine("3");
                int money_ = 1000;
                int bank_ = 5000;
                int dirtyMoney_ = 0;
                int count = (list == null) ? 0 : list.Count;
                if (count == 0)
                {
                    MYSQL.execute($"INSERT INTO playermoney (steamid,money,bank,dirty_money) VALUES ('{licenseIdentifier}','{money_}','{bank_}','{dirtyMoney_}');");
                    Debug.WriteLine($"Vytvarim hrace: {player.Name} [MONEYSYSTEM]");
                }
                else
                {
                    money_ = list[0].money;
                    bank_ = list[0].bank;
                    dirtyMoney_ = list[0].dirty_money;
                    Debug.WriteLine($"Nacitam hrace: {player.Name} [MONEYSYSTEM]");
                }
                MoneyPlayer money = new MoneyPlayer();

                money.setMoney     (id, money_);
                money.setBankMoney (id, bank_);
                money.setDirtyMoney(id, dirtyMoney_);

                PlayerMoneyHolder.saveMoneyPlayerToList(id, money);
            });
        }
    }
}
