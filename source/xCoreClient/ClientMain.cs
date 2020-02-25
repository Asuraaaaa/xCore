using CitizenFX.Core;
using System;
using System.Collections.Generic;
using xCoreClient.Main.Player.Group;
using xCoreClient.Main.Player.job;
using xCoreClient.Main.Player.money;
using xCoreClient.Main.Player.SoundSystem;
using xCoreClient.Main.Player.teleport;

namespace xCoreClient
{
    class ClientMain : BaseScript
    {
        public ClientMain()
        {
            //===================================//
            //            SoundSystem            //
            //===================================//
            Exports.Add("Play", new Action<string, float>((name, volume) => {
                PlayerSound.Play(name, volume);
            }));

            Exports.Add("PlayPos", new Action<string, float, Vector3>((name, volume, pos) => {
                PlayerSound.Play(name, volume, pos);
            }));

            Exports.Add("PlayUrl", new Action<string, string, float>((name, url, volume) => {
                PlayerSound.PLayUrl(name, url, volume);
            }));

            Exports.Add("PlayUrlPos", new Action<string, string, float, Vector3>((name, url, volume, pos) => {
                PlayerSound.PLayUrl(name, url, volume, pos);
            }));

            Exports.Add("Pause", new Action<string>((name) => {
                PlayerSound.Pause(name);
            }));

            Exports.Add("Stop", new Action<string>((name) => {
                PlayerSound.Stop(name);
            }));

            Exports.Add("Resume", new Action<string>((name) => {
                PlayerSound.Resume(name);
            }));

            Exports.Add("Distance", new Action<string, int>((name, disc) => {
                PlayerSound.Distance(name, disc);
            }));

            Exports.Add("Position", new Action<string, Vector3>((name, pos) => {
                PlayerSound.Position(name, pos);
            }));
            //===================================//
            //            MoneySystem            //
            //===================================//
            Exports.Add("getDirtyMoney", new Func<int>(PlayerMoney.getDirtyMoney));
            Exports.Add("getBankMoney", new Func<int> (PlayerMoney.getBankMoney));
            Exports.Add("getMoney", new Func<int>     (PlayerMoney.getMoney));
            //===================================//
            //             JobSystem             //
            //===================================//
            Exports.Add("getJob", new Func<string>  (PlayerJob.getJobName));
            Exports.Add("getGrade", new Func<string>(PlayerJob.getJobGrade));
            //===================================//
            //             GroupList             //
            //===================================//
            Exports.Add("isAtGroup",               new Func<string,bool>(PlayerGroup.isAtGroup));
            Exports.Add("getPlayerGroups", new Func<List<string>>(PlayerGroup.getPlayerGroups));
            //===================================//
            //             Teleport              //
            //===================================//
            Exports.Add("teleport", new Action<int, Vector3, float> ((entity, vec, heading) => {
                teleport.tele(entity, vec, heading);
            }));
        }
    }
}
