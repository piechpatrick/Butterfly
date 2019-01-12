using Butterfly.Server.Core;
using Butterfly.Server.Core.Instances;
using Butterfly.Server.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Server.Services
{
    public class ButterflyService : ServiceBase
    {
        private IButterflyServer _butterflyServer;
        private Thread _worker;
        public ButterflyService()
        {
            
        }

        protected override void OnStart(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Build();

            _butterflyServer = bootstrapper.Reslove<IButterflyServer>();
            _worker = new Thread(new ThreadStart(_butterflyServer.Start));
            _worker.Start();
        }

        protected override void OnStop()
        {
            _butterflyServer.Stop();
            _worker.Join();
        }
    }
}
