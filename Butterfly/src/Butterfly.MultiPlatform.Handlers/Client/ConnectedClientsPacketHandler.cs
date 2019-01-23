using Butterfly.MultiPlatform.Interfaces;
using Butterfly.MultiPlatform.Packets.Configuration;
using Networker.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.MultiPlatform.Handlers.Client
{
    public class ConnectedClientsPacketHandler : PacketHandlerBase<ConnectedClientsPacket>
    {
        public override Task Process(ConnectedClientsPacket packet, ISender sender)
        {
            return Task.Factory.StartNew(() =>
            {

            });
        }
    }
}
