using Butterfly.MultiPlatform.Interfaces;
using Butterfly.MultiPlatform.Packets.Video;
using Networker.Common;
using Networker.Common.Abstractions;
using Networker.Server.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Handlers.Video
{
    public class Nv21PacketHandler : PacketHandlerBase<Nv21FormatVideoPacket>
    {
        private readonly INetworkServer networkServer;
        public Nv21PacketHandler(INetworkServer networkServer)
        {
            this.networkServer = networkServer;
        }
        public override Task Process(Nv21FormatVideoPacket packet, ISender sender)
        {
            return Task.Factory.StartNew(() =>
            {
                
            });
            //this.networkServer.Send<Nv21FormatVideoPacket>(packet, sender.);
        }
    }
}
