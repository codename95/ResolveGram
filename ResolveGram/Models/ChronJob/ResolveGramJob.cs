using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ResolveGram.Models.ChronJob
{
    public class ResolveGramJob :IJob
    {
  
        Task IJob.Execute(IJobExecutionContext context)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"D:\Salem.txt", true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString());
            }
            throw new NotImplementedException();
        }
    }

    public class JobScheduler

    {

        public static async void Start()

        {

            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            scheduler.Start().Wait(1);

            IJobDetail job = JobBuilder.Create<ResolveGramJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()

                .WithIdentity("ResolveGramJob", "ResolveGram")

                .WithCronSchedule("0 0/1 * 1/1 * ? *")

                .StartAt(DateTime.Now)

                .WithPriority(1)

                .Build();

            scheduler.ScheduleJob(job, trigger).Wait(1);
            //

        }

    }
}