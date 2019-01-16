using Butterfly.MultiPlatform.Interfaces.Bulk;
using Butterfly.Server.Core;
using Butterfly.Server.Core.Server;
using Butterfly.Windows.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Server.Services
{
    public class ButterflyService : ServiceBase , IButterflyService
    {
        private Thread worker;
        private readonly IButterflyServer butterflyServer;
        public ButterflyService(IButterflyServer butterflyServer)
        {
            this.butterflyServer = butterflyServer;
        }

        protected override void OnStart(string[] args)
        {
            worker = new Thread(new ThreadStart(butterflyServer.Start));
            worker.Start();
        }

        protected override void OnStop()
        {
            butterflyServer.Stop();
            worker.Join();
        }
    }
}
