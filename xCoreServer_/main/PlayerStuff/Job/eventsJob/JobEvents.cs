using CitizenFX.Core;
using System.Collections.Generic;
using xCoreServer.Job;

namespace xCoreServer.main.Job.eventsJob
{
    class JobEvents : BaseScript
    {
       [EventHandler("xCore:Server:setJob")]
       public void setJob(int source,string jobName,string grade)
       {
            PlayerJob job = PlayerJobHolder.getPlayerJob(source);
            job.setPlayerJob(source, jobName, grade);
            PlayerJobHolder.savePlayerToList(source, job);
       }

        [EventHandler("xCore:Server:getJob")]
        public void getJobName(int source,dynamic value)
        {
            PlayerJob job = PlayerJobHolder.getPlayerJob(source);
            var args = new List<object>() { job.getJobName().ToString(), job.getJobGrade().ToString() };
            value(args);
        }
    }
}
