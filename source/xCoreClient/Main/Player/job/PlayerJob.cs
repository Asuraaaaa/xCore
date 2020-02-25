using CitizenFX.Core;
using System;

namespace xCoreClient.Main.Player.job
{
    public class PlayerJob : BaseScript
    {
        private static string jobName;
        private static string JobGrade;

        [EventHandler("xCore:client:setJob")]
        private void playerJobUpdated(string name,string grade)
        {
            jobName = name;
            JobGrade = grade;
        }

        public static string getJobName() => jobName;
        public static string getJobGrade() => JobGrade;

    }
}
