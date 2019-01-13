using System;
using Butterfly.MultiPlatform.Handlers.Client;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Packets.Pings;
using Networker.Common;

namespace Butterfly.MultiPlatform.Modules.HandlersModules
{
    public class DefaultPacketHandlerModule : PacketHandlerModuleBase
    {
        public DefaultPacketHandlerModule()
        {
            this.AddPacketHandler<PingPacket, ClientPingPacketHandler>();
            this.AddPacketHandler<ClientConfigurationPacket, ClientConfigurationPacketHandler>();
        }
    }
}
