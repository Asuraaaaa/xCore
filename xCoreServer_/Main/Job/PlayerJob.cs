using CitizenFX.Core;

namespace xCoreServer.Job
{
    class PlayerJob : BaseScript
    {
        private string jobName_;
        private string jobGrade_;

        public void setPlayerJob(int source,string job,string grade)
        {
            Player player = new PlayerList()[source];
            this.jobName_ = job;
            this.jobGrade_ = grade;
            player.TriggerEvent("xCore:client:setJob", job, grade);
        }

        public string getJobGrade() => this.jobGrade_;
        public string getJobName() => this.jobName_;
    }
}
