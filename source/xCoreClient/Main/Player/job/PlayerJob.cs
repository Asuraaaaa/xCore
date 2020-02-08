using CitizenFX.Core;
using System;
using System.Threading.Tasks;
using xCoreClient.main.Player;

namespace xCoreClient.Main.Player.job
{
    public class PlayerJob : BaseScript
    {
        public async Task<string> getJobName()
        {
            string jobName = await readEvent(0);
            return jobName;
        }

        public async Task<string> getJobGrade()
        {
            string jobName = await readEvent(1);
            return jobName;
        }

        private async Task<string> readEvent(int result)
        {
            string obj = null;
            bool finish = false;
            int letgo = 0;

            TriggerServerEvent("xCore:Server:getJob", ID.playerID(), new Action<dynamic>((value) => {
                obj = value[result];
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
