using CitizenFX.Core;
using System;
using System.Threading.Tasks;
using xCoreClient.main.Player;

namespace xCoreClient.Main.Player.job
{
    class PlayerJob : BaseScript
    {
        public async Task<string> getJobName()
        {
            string jobName = "null";
            bool finish = false;
            int letgo = 0;

            TriggerServerEvent("xCore:Server:getJob", ID.playerID(), new Action<dynamic>((value) => {
                jobName = value[0];
                finish = true;
            }));
            while (finish == false)
            {
                await Delay(50);
                if (++letgo == 4) finish = true;
            }
            return jobName;
        }

        public async Task<string> getJobGrade()
        {
            string jobName = "null";
            int letgo = 0;
            bool finish = false;
            TriggerServerEvent("xCore:Server:getJob", ID.playerID(), new Action<dynamic>((value) => {
                jobName = value[1];
                finish = true;
            }));
            while (finish == false)
            {
                await Delay(50);
                if (++letgo == 4) finish = true;
            }
            return jobName;
        }
    }
}
