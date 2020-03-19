using CitizenFX.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using xCoreClient.Main.Player.job;

namespace xCoreClient.Main.Player.Markers.Draw
{
    class MarkInit : BaseScript
    {
        static Vector3 playerPos;
        static List<MarkClass> show = new List<MarkClass>();
        static List<MarkClass> callbacks = new List<MarkClass>();
        static MarkClass mark;

        [EventHandler("xCore:client:keyEvent")]
        public void markerKey(int key)
        {
            playerPos = Game.Player.Character.Position;
            for (int i = 0; i < show.Count; i++)
            {
                mark = show[i];
                if (World.GetDistance(playerPos, mark.getPosition()) < (mark.getScale().X + 0.3f))
                {
                    mark.onKeyDelegate().DynamicInvoke(key);
                }
            }
        }

        public static async Task SaveMarkers()
        {
            while (true)
            {
                await Delay(500);
                show.Clear();
                playerPos = Game.Player.Character.Position;

                for (int i = 0; i < MarkerHolder.MarkerList.Count; i++)
                {
                    mark = MarkerHolder.MarkerList[i];
                    if (mark.getJobList().Count != 0)
                    {
                        if (!mark.getJobs(PlayerJob.getJobName(), PlayerJob.getJobGrade())) continue;
                    }
                    if (World.GetDistance(playerPos, mark.getPosition()) < mark.getDistance()) show.Add(mark);
                    if (World.GetDistance(playerPos, mark.getPosition()) < (mark.getScale().X + 0.3f))
                    {
                        if (!callbacks.Contains(mark))
                        {
                            callbacks.Add(mark);
                            mark.onEnterDelegate().DynamicInvoke();
                        }
                    }
                }

                for (int i = 0; i < callbacks.Count; i++)
                {
                    mark = callbacks[i];
                    if (!(World.GetDistance(playerPos, mark.getPosition()) < (mark.getScale().X + 0.3f)))
                    {
                        if (callbacks.Contains(mark))
                        {
                            callbacks.Remove(mark);
                            mark.onExitDelegate().DynamicInvoke();
                        }
                    }
                }
            }
        }

        public static async Task DrawMarkers()
        {
            while (true)
            {
                await Delay(0);
                if(show.Count == 0)
                {
                    await Delay(1000);
                    continue;
                }
                for (int i = 0; i < show.Count; i++)
                {
                    mark = show[i];                   
                    mark.drawMarker();
                }
            }
        }
    }
}
