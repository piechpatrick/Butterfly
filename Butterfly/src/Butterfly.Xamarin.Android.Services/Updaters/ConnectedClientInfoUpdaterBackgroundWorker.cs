using Butterfly.MultiPlatform.Common.Background.Workers;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Senders;
using Butterfly.MultiPlatform.ViewModels;
using Butterfly.MultiPlatform.ViewModels.Identities;
using Butterfly.Xamarin.Core;
using Networker.Client.Abstractions;
using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Butterfly.Xamarin.Android.Services.Updaters
{
    internal class ConnectedClientInfoUpdaterBackgroundWorker : BackgroundWorkingThreadBase
    {
        private GenericTCPPacketSender<ConnectedClientInfoPacket> genericTCPPacketSender;
        private readonly INetworkClient networkClient;
        public ConnectedClientInfoUpdaterBackgroundWorker(INetworkClient networkClient)
            : base(5000, ThreadPriority.AboveNormal)
        {
            this.networkClient = networkClient;
            this.genericTCPPacketSender = new GenericTCPPacketSender<ConnectedClientInfoPacket>(networkClient);
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
            this.networkClient.Send(this.GetPacket());
        }

        private ConnectedClientInfoPacket GetPacket()
        {
            return new ConnectedClientInfoPacket()
            {
                ConnectedClientViewModel = new ConnectedClientViewModel()
                {
                    
                }
            };

        }
    }
}
