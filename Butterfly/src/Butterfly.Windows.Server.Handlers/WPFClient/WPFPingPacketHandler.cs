using Butterfly.MultiPlatform.Packets.Pings;
using Microsoft.Extensions.Logging;
using Networker.Common;
using Networker.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Handlers.WPFClient
{
    public class WPFPingPacketHandler : PacketHandlerBase<PingPacket>
    {
        private readonly ILogger<WPFPingPacketHandler> logger;
        public WPFPingPacketHandler(ILogger<WPFPingPacketHandler> logger )
        {
            this.logger = logger;
        }

        public override Task Process(PingPacket packet, ISender sender)
        {
            return null; 
        }
    }
}
