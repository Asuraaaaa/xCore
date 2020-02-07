using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;

namespace xMenuClient.Main.Job
{
    class jobCommand : BaseScript
    {

        public static int playerID()
        {
            return API.GetPlayerServerId(API.NetworkGetEntityOwner(API.PlayerPedId()));
        }

        [Command("getjob")]
        void getjob()
        {
            TriggerServerEvent("xCore:Server:getJob", playerID(), new Action<dynamic>((value) =>
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
                Debug.WriteLine(result + "");
            }));
        }
    }
}
