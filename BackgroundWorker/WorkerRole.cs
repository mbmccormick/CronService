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
                // connect to the database
                DatabaseDataContext db = new DatabaseDataContext();

                // fetch all scheduled jobs that are overdue and enabled
                foreach (Schedule s in db.Schedules.Where(z => z.NextOccurrence <= DateTime.UtcNow &&
                                                               z.IsEnabled == true))
                {
                    // execute job
                    Job job = new Job(s);

                    Thread jobThread = new Thread(new ThreadStart(job.Execute));
                    jobThread.Start();

                    // schedule next occurrence
                    CrontabSchedule schedule = CrontabSchedule.Parse(s.Occurrence);
                    DateTime nextOccurrence = schedule.GetNextOccurrence(DateTime.UtcNow); // calculate new next occurrence

                    s.NextOccurrence = nextOccurrence;

                    db.SubmitChanges();
                }

                // close connection
                db.Dispose();

                if (Debugger.IsAttached == true)
                    Thread.Sleep(10000); // sleep for ten seconds
                else
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
        public Schedule Schedule;

        public Job(Schedule schedule)
        {
            Schedule = schedule;
        }

        public void Execute()
        {
            HttpStatusCode result = HttpStatusCode.OK;
            string content = "";

            try
            {
                // request the http endpoint
                WebClient client = new WebClient();
                content = client.DownloadString(Schedule.Endpoint);

                // close connection
                client.Dispose();
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                    result = ((HttpWebResponse)ex.Response).StatusCode;
            }

            // log information to database
            this.LogInformation(result, content);
        }

        private void LogInformation(HttpStatusCode result, string content)
        {
            // connect to the database
            DatabaseDataContext db = new DatabaseDataContext();

            // create new information
            Information log = new Information();

            // set information properties
            log.ID = Guid.NewGuid();
            log.ScheduleID = Schedule.ID;
            log.Result = (int)result;
            if (log.Result != 200)
                log.Message = content;
            log.CreatedDate = DateTime.UtcNow;

            // insert information to database
            db.Informations.InsertOnSubmit(log);
            db.SubmitChanges();

            // close connection
            db.Dispose();
        }
    }
}
