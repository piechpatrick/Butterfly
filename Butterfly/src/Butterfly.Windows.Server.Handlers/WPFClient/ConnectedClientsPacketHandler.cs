using Butterfly.MultiPlatform.Interfaces;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.Windows.WPF.Client.Common.Events;
using Networker.Common;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Handlers.WPFClient
{
    public class ConnectedClientsPacketHandler : PacketHandlerBase<ConnectedClientsPacket>
    {
        IEventAggregator eventAggregator;
        public ConnectedClientsPacketHandler(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }
        public override Task Process(ConnectedClientsPacket packet, ISender sender)
        {
            return Task.Factory.StartNew(() =>
            {
                eventAggregator.GetEvent<ConnectedClientsPacketEvent>().Publish(packet);
            });
        }
    }
}
