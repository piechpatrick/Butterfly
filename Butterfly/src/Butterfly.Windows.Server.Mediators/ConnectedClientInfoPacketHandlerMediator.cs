using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butterfly.MultiPlatform.Interfaces.Mediators;
using Butterfly.MultiPlatform.Packets;
using Butterfly.MultiPlatform.Packets.Configuration;

namespace Butterfly.Windows.Server.Mediators
{
    public class ConnectedClientInfoPacketHandlerMediator : 
        IMediator<ConnectedClientInfoPacket, MediatableBase<ConnectedClientInfoPacket, ConnectedClientInfoPacketHandlerMediator>>
    {

        public ConnectedClientInfoPacketHandlerMediator()
        {

        }
        public void Send(ConnectedClientInfoPacket message, MediatableBase<ConnectedClientInfoPacket, ConnectedClientInfoPacketHandlerMediator> mediatable)
        {
            
        }
    }
}
