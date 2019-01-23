using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.ViewModels;
using Butterfly.Windows.WPF.Client.Common.Events;
using Networker.Client.Abstractions;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.Core.Client
{
    public class ButterflyWPFClient : IButterflyWPFClient
    {
        private readonly INetworkClient networkClient;
        private readonly IEventAggregator eventAggregator;
        public ButterflyWPFClient(INetworkClient networkClient,
            IEventAggregator eventAggregator)
        {
            this.networkClient = networkClient;
            this.eventAggregator = eventAggregator;
        }

        public void Start()
        {
            try
            {
                this.networkClient.Connect();

                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        this.networkClient.Send<ConnectedClientInfoPacket>(
                            new ConnectedClientInfoPacket()
                            {
                                ConnectedClientViewModel = new ConnectedClientViewModel()
                                {
                                    IsAdmin = true,
                                    Machine = "PC",
                                    Name = "Patryk"
                                }
                            });
                        Thread.Sleep(10000);
                    }
                });
            }
            catch(Exception ex)
            {

            }

        }

        
    }
}
