using CitizenFX.Core;
using CitizenFX.Core.UI;
using System;
using System.Threading.Tasks;
using xCoreClient.main.Player;
using xCoreClient.Main.Player.money;

namespace xMenuClient.Main.Job
{
    class jobCommand : BaseScript
    {
        [Command("addgroup")]
        void addGroup(string[] args)
        {
            TriggerServerEvent("xCore:Server:addPlayerGroup", ID.playerID(), args[0]);
        }

        [Command("removeGroup")]
        void removeGroup(string[] args)
        {
            TriggerServerEvent("xCore:Server:removePlayerGroup", ID.playerID(), args[0]);
        }

        [Command("givemoney")]
        void givemoney(string[] args)
        {
            int money = 0;
            Int32.TryParse(args[1], out money);
            TriggerServerEvent("xCore:Server:addMoney", ID.playerID(), args[0], money);
        }

        [Command("setmoney")]
        void setmoney(string[] args)
        {
            int money = 0;
            Int32.TryParse(args[1], out money);
            TriggerServerEvent("xCore:Server:setMoney", ID.playerID(), args[0], money);
        }

        [Command("getmoney")]
        void savemoneyAsync()
        {
            PlayerMoney money = new PlayerMoney();

            int money_ = money.getMoney();
            int bank_  = money.getBankMoney();
            int dirty_ = money.getDirtyMoney();

            Screen.ShowNotification($"Money:      {money_}");
            Screen.ShowNotification($"Bank:       {bank_}");
            Screen.ShowNotification($"DirtyMoney: {dirty_}");
        }

        [Command("getjob")]
        void getjob()
        {
            TriggerServerEvent("xCore:Server:getJob", ID.playerID(), new Action<dynamic>((value) =>
            {
                TriggerEvent("chatMessage", "PRACE VOLE", new[] { 255, 0, 0 }, $"{value[0]}");
                TriggerEvent("chatMessage", "PRACE VOLE", new[] { 255, 0, 0 }, $"{value[1]}");
            }));
        }


        [Command("setjob")]
        void jobSet(string[] args)
        {
            if (args[0] == null || args[1] == null || args[2] == null)
            {
                TriggerEvent("chatMessage", "/setJob",new[] { 255, 0, 0}, " <id, name, grade>");
                return;
            }
            TriggerServerEvent("xMenu:server:setJobCommand", args[0], args[1], args[2], new Action<object>((result) =>
            {
                if((bool)result == false) TriggerEvent("chatMessage", "/setJob", new[] { 255, 0, 0 }, " prace neexistuje!");
            }));
        }
    }
}
