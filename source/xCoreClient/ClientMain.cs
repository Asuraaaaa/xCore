using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using xCoreClient.Main.Player.job;

namespace xCoreClient
{
    class ClientMain : BaseScript
    {      
        public ClientMain()
        {          

        }

        [Command("save")]
        void test()
        {
            PlayerJob job = new PlayerJob();

            string name =  job.getJobName();
            string grade = job.getJobGrade();

            Screen.ShowNotification($"{name}:{grade}");
            
        }
    }
}
