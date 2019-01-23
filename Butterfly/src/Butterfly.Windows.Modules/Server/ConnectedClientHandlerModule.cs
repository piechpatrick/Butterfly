using Butterfly.MultiPlatform.Handlers.Client;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.Windows.Server.Handlers.Server;
using Networker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Modules.Server
{
    public class ConnectedClientHandlerModule : PacketHandlerModuleBase
    {
        public ConnectedClientHandlerModule()
        {
            this.AddPacketHandler<ConnectedClientInfoPacket, ConnectedClientInfoHandler>();
            this.AddPacketHandler<ConnectedClientsPacket, ConnectedClientsPacketHandler>();
        }
    }
}
