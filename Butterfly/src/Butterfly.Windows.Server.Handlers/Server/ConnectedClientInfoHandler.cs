using Butterfly.MultiPlatform.Interfaces;
using Butterfly.MultiPlatform.Interfaces.Mediators;
using Butterfly.MultiPlatform.Packets;
using Butterfly.MultiPlatform.Packets.Configuration;
using Networker.Common;
using Networker.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Handlers.Server
{
    public class ConnectedClientInfoHandler : PacketHandlerBase<ConnectedClientInfoPacket>
    {
        private IConnectedClientInfoPacketHandlerMediator connectedClientInfoPacketHandlerMediator;
        public ConnectedClientInfoHandler(IConnectedClientInfoPacketHandlerMediator connectedClientInfoPacketHandlerMediator)
        {
            this.connectedClientInfoPacketHandlerMediator = connectedClientInfoPacketHandlerMediator;
        }
        public override Task Process(ConnectedClientInfoPacket packet, ISender sender)
        {
            return Task.Factory.StartNew(() =>
            {
                new PacketHandlerAdapter(this.connectedClientInfoPacketHandlerMediator,sender).Send(packet);
            });
        }
    }

    public class PacketHandlerAdapter
        : IMediatable<ConnectedClientInfoPacket>
    {
        private readonly IConnectedClientInfoPacketHandlerMediator connectedClientInfoPacketHandlerMediator;

        public ISender Sender { get; set; }
        public PacketHandlerAdapter(IConnectedClientInfoPacketHandlerMediator connectedClientInfoPacketHandlerMediator, ISender sender)
        {
            this.connectedClientInfoPacketHandlerMediator = connectedClientInfoPacketHandlerMediator;
            this.Sender = sender;
        }

        public void Send(ConnectedClientInfoPacket message)
        {
            this.connectedClientInfoPacketHandlerMediator.Send(message, this);
        }
    }

    public interface IConnectedClientInfoPacketHandlerMediator : IMediator<ConnectedClientInfoPacket>
    {

    }

  


}
