using CitizenFX.Core;
using System;

namespace xCoreClient.Main.Player.job
{
    public class PlayerJob : BaseScript
    {
        private string jobName;
        private string JobGrade;

        [EventHandler("xCore:client:setJob")]
        private void playerJobUpdated(string name,string grade)
        {
            this.jobName = name;
            this.JobGrade = grade;
        }

        public string getJobName() => this.jobName;
        public string getJobGrade() => this.JobGrade;

    }
}
