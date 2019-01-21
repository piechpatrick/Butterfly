using Butterfly.MultiPlatform.Packets.Video;
using Butterfly.Windows.Server.Handlers.Video;
using Networker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Modules.Common
{
    public class VideoPacketHandlerModule : PacketHandlerModuleBase
    {
        public VideoPacketHandlerModule()
        {
            this.AddPacketHandler<Nv21FormatVideoPacket, Nv21PacketHandler>();
        }
    }
}
