using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;

namespace xMenuClient.Main.Job
{
    class jobCommand : BaseScript
    {
        public static int playerID()
        {
            return API.GetPlayerServerId(API.NetworkGetEntityOwner(API.PlayerPedId()));
        }

        [Command("addgroup")]
        void addGroup(string[] args)
        {
            TriggerServerEvent("xCore:Server:addPlayerGroup", playerID(), args[0]);
        }

        [Command("removeGroup")]
        void removeGroup(string[] args)
        {
            TriggerServerEvent("xCore:Server:removePlayerGroup", playerID(), args[0]);
        }

        [Command("givemoney")]
        void givemoney(string[] args)
        {
            int money = 0;
            Int32.TryParse(args[1], out money);
            TriggerServerEvent("xCore:Server:addMoney", playerID(), args[0], money);
        }

        [Command("setmoney")]
        void setmoney(string[] args)
        {
            int money = 0;
            Int32.TryParse(args[1], out money);
            TriggerServerEvent("xCore:Server:setMoney", playerID(), args[0], money);
        }

        [Command("getmoney")]
        void savemoneyAsync()
        {
            dynamic list = Exports["xCoreMaster"];

            int money_ = list.getMoney();
            int bank_  = list.getBankMoney();
            int dirty_ = list.getDirtyMoney();

            Screen.ShowNotification($"Money:      {money_}");
            Screen.ShowNotification($"Bank:       {bank_}");
            Screen.ShowNotification($"DirtyMoney: {dirty_}");
        }

        [Command("getjob")]
        void getjob()
        {
            dynamic list = Exports["xCoreMaster"];

            string name =  list.getJob();
            string grade = list.getGrade();

            TriggerEvent("chatMessage", "PRACE VOLE", new[] { 255, 0, 0 }, $"{name}");
            TriggerEvent("chatMessage", "PRACE VOLE", new[] { 255, 0, 0 }, $"{grade}");
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
