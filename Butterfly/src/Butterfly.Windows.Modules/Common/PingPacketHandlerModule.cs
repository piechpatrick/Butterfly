﻿using Butterfly.MultiPlatform.Packets.Pings;
using Butterfly.Windows.Handlers.Network;
using Networker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Modules.Common
{
    public class PingPacketHandlerModule : PacketHandlerModuleBase
    {
        public PingPacketHandlerModule()
        {
            this.AddPacketHandler<PingPacket, PingPacketHandler>();
        }
    }
}
