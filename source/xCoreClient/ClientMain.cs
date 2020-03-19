using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using xCoreClient.Main.Player.Group;
using xCoreClient.Main.Player.job;
using xCoreClient.Main.Player.Markers;
using xCoreClient.Main.Player.Markers.Draw;
using xCoreClient.Main.Player.money;
using xCoreClient.Main.Player.SoundSystem;
using xCoreClient.Main.Player.teleport;

namespace xCoreClient
{
    class ClientMain : BaseScript
    {     
        public ClientMain()
        {
            #region timers for markers

            MarkInit.SaveMarkers();
            MarkInit.DrawMarkers();

            #endregion

            #region timer for key events

            KeyEvent.IsAnyControlJustPressed();

            #endregion

            #region Exports for sound system

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
            #endregion

            #region Exports for Money System

            Exports.Add("getDirtyMoney", new Func<int>(PlayerMoney.getDirtyMoney));
            Exports.Add("getBankMoney", new Func<int> (PlayerMoney.getBankMoney));
            Exports.Add("getMoney", new Func<int>     (PlayerMoney.getMoney));

            #endregion

            #region Exports for job system

            Exports.Add("getJob", new Func<string>  (PlayerJob.getJobName));
            Exports.Add("getGrade", new Func<string>(PlayerJob.getJobGrade));

            #endregion

            #region Exports for Group system

            Exports.Add("isAtGroup",               new Func<string,bool>(PlayerGroup.isAtGroup));
            Exports.Add("getPlayerGroups", new Func<List<string>>(PlayerGroup.getPlayerGroups));

            #endregion

            #region Exports for pickup

            /*
            Exports.Add("drawMarker", new Action<int, Vector3, Vector3,int,int, dynamic, dynamic, dynamic, string,dynamic>(
                (type, pos, scale, col, distance, key, enter,exit, job, grade) => {
                MarkClass mark = new MarkClass();

                mark.setPosition(pos);
                mark.setScale(scale);
                mark.setMarkerType(MarkerType.BoatSymbol);
                mark.setColor(Color.FromArgb(255, 255, 255));
                mark.setDistance(distance);

                mark.onEnter(enter);

                mark.onExit(exit);

                mark.onKey(key);

                mark.visibleToJob(job, grade);

                MarkerHolder.saveMarket(mark);
            }));
            */

            #endregion

            #region Exports for other things

            Exports.Add("teleport", new Action<int, Vector3, float> ((entity, vec, heading) => {
                teleport.tele(entity, vec, heading);
            }));

            #endregion

            /*
            Exports["xCoreMaster"].drawMarker(38,
                new Vector3(1854.44f, 2594.72f, 45.5f),
                new Vector3(1, 1, 1),
                5,
                1000,
                new Action<int>((key) =>
                {
                    Screen.ShowNotification("KeyPushed: " + key);
                }),
                new Action(() =>
                {
                    Screen.ShowNotification("JouJou ENTER: " + new Random().Next(1000));
                }),
                new Action(() =>
                {
                    Screen.ShowNotification("JouJou Exit: " + new Random().Next(1000));
                })
                ,
                "unemployed"
                ,
                new List<string>
                {
                    "unemployed",
                }
            );
            */

            /*
            MarkClass mark = new MarkClass();

            mark.setPosition(new Vector3(1854.44f, 2594.72f, 45.5f));
            mark.setScale(new Vector3(1, 1, 1));
            mark.setMarkerType(MarkerType.VerticalCylinder);
            mark.setColor(Color.FromArgb(255, 255, 255));
            mark.setDistance(10000);

            mark.onEnter(new Action(() =>
            {
                Screen.ShowNotification("JouJou ENTER: " + new Random().Next(1000));
            }));

            mark.onExit(new Action(() =>
            {
                Screen.ShowNotification("EXIT JouJou: " + new Random().Next(1000));
            }));

            mark.onKey(new Action<int>((key) =>
            {
                Screen.ShowNotification("KeyPushed: " + key);
            }));

            mark.visibleToJob("unemployed", new List<string>
                {
                    "unemployed",
                });

            MarkerHolder.saveMarket(mark);
            */
        }
    }
}
