using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Packets.Pings;
using Butterfly.MultiPlatform.Packets.Video;
using Butterfly.Windows.Server.Handlers.WPFClient;
using Networker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Modules.Client
{
    public class WPFClientHandlerModule : PacketHandlerModuleBase
    {
        public WPFClientHandlerModule()
        {
            this.AddPacketHandler<PingPacket, WPFPingPacketHandler>();
            this.AddPacketHandler<Nv21FormatVideoPacket, WPFNv21VideoPacketHandler>();
            this.AddPacketHandler<ConnectedClientsPacket, ConnectedClientsPacketHandler>();
        }
    }
}
