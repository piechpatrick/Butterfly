using Butterfly.MultiPlatform.Packets.Pings;
using Microsoft.Extensions.Logging;
using Networker.Common;
using Networker.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Handlers.Network
{
    public class PingPacketHandler : PacketHandlerBase<PingPacket>
    {
        private readonly ILogger<PingPacketHandler> logger;

        public PingPacketHandler(ILogger<PingPacketHandler> logger)
        {
            this.logger = logger;
        }

        public override async Task Process(PingPacket packet, ISender sender)
        {
            this.logger.LogDebug("Received a ping packet from " + sender.EndPoint);
        }
    }
}
