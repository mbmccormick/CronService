using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using NCrontab;
using BackgroundWorker.Common;

namespace BackgroundWorker
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            while (true)
            {
                DatabaseDataContext db = new DatabaseDataContext();

                // fetch all scheduled jobs that are overdue and enabled
                foreach (Schedule s in db.Schedules.Where(z => z.NextOccurrence <= DateTime.UtcNow &&
                                                               z.IsEnabled == true))
                {
                    // execute job
                    Job job = new Job(s.Endpoint);

                    Thread jobThread = new Thread(new ThreadStart(job.Execute));
                    jobThread.Start();
                    
                    // schedule next occurrence
                    CrontabSchedule schedule = CrontabSchedule.Parse(s.Occurrence);
                    DateTime nextOccurrence = schedule.GetNextOccurrence(s.NextOccurrence); // calculate new next occurrence

                    s.NextOccurrence = nextOccurrence;

                    db.SubmitChanges();                    
                }

                db.Dispose();

                Thread.Sleep(60000); // sleep for one minute
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            return base.OnStart();
        }
    }

    public class Job
    {
        public string Endpoint;

        public Job(string endpoint)
        {
            Endpoint = endpoint;
        }

        public void Execute()
        {
            WebClient client = new WebClient();
            client.DownloadData(Endpoint);

            client.Dispose();
        }
    }
}
