using Butterfly.MultiPlatform.Interfaces;
using Butterfly.MultiPlatform.Packets.Audio;
using Butterfly.Windows.Services.Audio;
using Microsoft.Extensions.Logging;
using Networker.Common;
using Networker.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Windows.Handlers.Audio
{
    public class PCMPacketHandler : PacketHandlerBase<PCMPacket>
    {
        private readonly ILogger<PCMPacketHandler> logger;
        private readonly AudioService audioService;
        private MemoryStream ms;
        int idx = 0;

        public PCMPacketHandler(ILogger<PCMPacketHandler> logger)
        {
            this.logger = logger;
            this.audioService = new AudioService();
            this.ms = new MemoryStream();
        }

        public override async Task Process(PCMPacket packet, ISender sender)
        {
            this.audioService?.Start();
            this.audioService?.Fill(packet);           
        }
    }
}
