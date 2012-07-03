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

namespace BackgroundWorker
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            Trace.WriteLine("BackgroundWorker entry point called", "Information");

            while (true)
            {
                Thread.Sleep(60000); // execute every one minute

                Trace.WriteLine("Working", "Information");

                WebClient client = new WebClient();
                client.DownloadData("http://metermaid.azurewebsites.net/execute.aspx");

                client.Dispose();
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            return base.OnStart();
        }
    }
}
