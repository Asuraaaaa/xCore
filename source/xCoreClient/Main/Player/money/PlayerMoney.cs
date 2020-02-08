using CitizenFX.Core;
using System;
using System.Threading.Tasks;
using xCoreClient.main.Player;

namespace xCoreClient.Main.Player.money
{
    public class PlayerMoney : BaseScript
    {
        public async Task<int> getMoney()
        {
            int money = await readEvent("money");
            return money;
        }

        public async Task<int> getBankMoney()
        {
            int money = await readEvent("bankmoney");
            return money;
        }

        public async Task<int> getDirtyMoney()
        {
            int money = await readEvent("dirtymoney");
            return money;
        }

        private async Task<int> readEvent(string result)
        {
            int obj = Int32.MinValue;
            bool finish = false;
            int letgo = 0;

            TriggerServerEvent("xCore:Server:getPlayerMoney", ID.playerID(), result, new Action<dynamic>((value) => {
                obj = value;
                finish = true;
            }));
            while (finish == false)
            {
                await Delay(50);
                if (++letgo == 4) finish = true;
            }
            return obj;
        }
    }
}
