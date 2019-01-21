using Butterfly.MultiPlatform.Common.Background.Workers;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Senders;
using Butterfly.MultiPlatform.ViewModels;
using Butterfly.MultiPlatform.ViewModels.Identities;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Butterfly.Xamarin.Android.Services.Updaters
{
    internal class ConnectedClientInfoUpdaterBackgroundWorker : BackgroundWorkingThreadBase
    {
        private GenericTCPPacketSender<ConnectedClientInfoPacket> genericTCPPacketSender;
        public ConnectedClientInfoUpdaterBackgroundWorker(INetworkClient client)
            : base(5000, ThreadPriority.AboveNormal)
        {
            this.genericTCPPacketSender = new GenericTCPPacketSender<ConnectedClientInfoPacket>(client);
        }
        protected override void OnError(Thread thread, Exception exception)
        {
            
        }

        protected override void OnFinished(Thread thread)
        {
            this.Start();
        }

        protected override void OnStart(Thread thread)
        {
            
        }

        protected override void Work()
        {
            var packet = new ConnectedClientInfoPacket()
            {
                ConnectedClientViewModel = new ConnectedClientViewModel()
                {
                    Name = "Roman"
                }
            };
            this.genericTCPPacketSender.Send(packet);
        }
    }
}
