using Butterfly.MultiPlatform.Interfaces;
using Butterfly.MultiPlatform.Packets.Video;
using Networker.Common;
using Networker.Common.Abstractions;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Handlers.WPFClient
{
    public class WPFNv21VideoPacketHandler : PacketHandlerBase<Nv21FormatVideoPacket>
    {
        public WPFNv21VideoPacketHandler(IPacketSerialiser packetSerialiser)
            : base(packetSerialiser)
        {

        }
        public override Task Process(Nv21FormatVideoPacket packet, ISender sender)
        {
            return Task.Factory.StartNew(() =>
            {
                
            });
        }
    }
}
