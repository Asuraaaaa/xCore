using CitizenFX.Core;

namespace xCoreClient.main.Job
{
    class PlayerJob : BaseScript
    {
        private string jobName_;
        private string jobGrade_;

        public void setPlayerJob(string job,string grade)
        {
            this.jobName_ = job;
            this.jobGrade_ = grade;
            TriggerEvent("xCore:client:setJob", job, grade);
        }

        public string getJobGrade() => this.jobGrade_;
        public string getJobName() => this.jobName_;
    }
}
