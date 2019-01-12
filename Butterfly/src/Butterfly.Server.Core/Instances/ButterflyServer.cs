using Butterfly.Maps.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Server.Core.Instances
{
    public class ButterflyServer : IButterflyServer
    {
        private bool run;
        private readonly IUserMap userMap;
        public ButterflyServer(IUserMap userMap)
        {
            this.userMap = userMap;
        }
        public void Start()
        {
            try
            {
                this.userMap.Create(new ViewModels.Identities.UserViewModel() { Name = "admin", Password = "#hash#" });

                int threadsCount, k;
                ThreadPool.GetMaxThreads(out threadsCount, out k);


                run = true;
                while (run)
                {
                    Thread.Sleep(500);
                }
            }
            catch
            {
                
            }
        }

        public void Stop()
        {
            
        }
    }
}
