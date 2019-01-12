using Butterfly.Maps.Entities;
using Butterfly.Windows.Modules.HandlersModules;
using Microsoft.Extensions.Logging;
using Networker.Formatter.ProtobufNet;
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


        public Networker.Server.Abstractions.IServer NetworkServer { get; private set; }

        public ButterflyServer()
        {

        }
        public void Start()
        {

            this.NetworkServer = new Networker.Server.ServerBuilder().UseTcp(1000)
                                            .SetMaximumConnections(6000)
                                            .UseUdp(5000)
                                            .ConfigureLogging(loggingBuilder =>
                                            {
                                                loggingBuilder.SetMinimumLevel(
                                                    LogLevel.Debug);
                                            })                                           
                                            .RegisterPacketHandlerModule<PingPacketHandlerModule>()
                                            .UseProtobufNet()
                                            .Build();

            try
            {
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
