using Butterfly.MultiPlatform.Packets.Audio;
using Microsoft.Extensions.Logging;
using Networker.Common;
using Networker.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Handlers.Audio
{
    public class PCMPacketHandler : PacketHandlerBase<PCMPacket>
    {
        private readonly ILogger<PCMPacketHandler> logger;

        public PCMPacketHandler(ILogger<PCMPacketHandler> logger)
        {
            this.logger = logger;
        }

        public override async Task Process(PCMPacket packet, ISender sender, byte[] data)
        {
            this.logger.LogDebug("Received a ping packet from " + sender.EndPoint);
        }
    }
}
