using CitizenFX.Core;
using CitizenFX.Core.UI;
using System;
using xCoreClient.Main.Player.job;
using xCoreClient.Main.Player.money;
using xCoreClient.Main.Player.SoundSystem;

namespace xCorePlayer
{
    public class main : BaseScript
    {
        public main()
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

            Exports.Add("Distance", new Action<string, int>((name,disc) => {
                PlayerSound.Distance(name, disc);
            }));

            Exports.Add("Position", new Action<string, Vector3>((name, pos) => {
                PlayerSound.Position(name, pos);
            }));
            //===================================//
            //            MoneySystem            //
            //===================================//
            Exports.Add("getDirtyMoney", new Func<int>(PlayerMoney.getDirtyMoney));
            Exports.Add("getBankMoney",  new Func<int>(PlayerMoney.getBankMoney));
            Exports.Add("getMoney",      new Func<int>(PlayerMoney.getMoney));
            //===================================//
            //             JobSystem             //
            //===================================//
            Exports.Add("getJob",   new Func<string>(PlayerJob.getJobName));
            Exports.Add("getGrade", new Func<string>(PlayerJob.getJobGrade));
        }

        [Command("wtf")]
        void wtfjob()
        {
            dynamic list = Exports["xCoreMaster"];

            string money = list.getJob();
            string bank =  list.getGrade();
            Screen.ShowNotification(money + " job");
            Screen.ShowNotification(bank + " grade");

            //Exports["SoundSystem"].Played("clap", 0.2f);
        }

        [Command("monisky")]
        void playcmd()
        {
            dynamic list = Exports["xCoreMaster"];

            int money = list.getMoney();
            int bank = list.getBankMoney();
            int dirky = list.getDirtyMoney();
            Screen.ShowNotification(money + " penez");
            Screen.ShowNotification(bank + " banka");
            Screen.ShowNotification(dirky + " dirty");

            //Exports["SoundSystem"].Played("clap", 0.2f);
        }
    }
}
