using Butterfly.MultiPlatform.Packets.Pings;
using Butterfly.Windows.Handlers.WPFClient;
using Butterfly.Windows.WPF.Client.Core.Client;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.ViewModels
{
    public class ViewModelBase
    {
        protected readonly IButterflyWPFClient wpfClient;
        protected readonly INetworkClient networkClient;
        protected readonly WPFPingPacketHandler pingPacket;

        public ViewModelBase(IButterflyWPFClient wpfClient, INetworkClient netClient, WPFPingPacketHandler pingPacket)
        {
            this.wpfClient = wpfClient;
            this.pingPacket = pingPacket;
            this.networkClient = netClient;
            this.pingPacket.OnPacketRecived += PingPacket_OnPacketRecived;
        }

        private void PingPacket_OnPacketRecived(object sender, InjectablePacketEventArgs<PingPacket, Networker.Common.Abstractions.ISender> e)
        {
            this.OnPingPacketRecive(e);
        }

        protected virtual void OnPingPacketRecive(InjectablePacketEventArgs<PingPacket, Networker.Common.Abstractions.ISender> ping)
        {

        }
    }
}
