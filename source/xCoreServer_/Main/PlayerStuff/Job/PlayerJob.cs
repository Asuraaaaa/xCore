using CitizenFX.Core;
 
namespace xCoreServer.Job
{
    public class PlayerJob : BaseScript
    {
        private string jobName_;
        private string jobGrade_;
        private Player player_;

        public void setPlayer(Player player) => this.player_ = player;
        public Player getPlayer() => this.player_;

        public void setPlayerJob(string job,string grade)
        {
            Player player = getPlayer();
            this.jobName_ = job;
            this.jobGrade_ = grade;
            player.TriggerEvent("xCore:client:setJob", job, grade);
        }

        public void setPlayerJob(Player source, string job, string grade)
        {
            this.jobName_ = job;
            this.jobGrade_ = grade;
            source.TriggerEvent("xCore:client:setJob", job, grade);
        }

        public string getJobGrade() => this.jobGrade_;
        public string getJobName() => this.jobName_;
    }
}
