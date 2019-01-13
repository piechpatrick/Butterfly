using Butterfly.MultiPlatform.Packets.Configuration;
using Networker.Common;
using Networker.Common.Abstractions;
using Networker.Formatter.ZeroFormatter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Handlers.Client
{
    public class ClientConfigurationPacketHandler : PacketHandlerBase<ClientConfigurationPacket>
    {
        public ClientConfigurationPacketHandler(IPacketSerialiser packetSerialiser)
            : base(packetSerialiser) { }

        public override async Task Process(ClientConfigurationPacket packet, ISender sender, byte[] data)
        {
            ClientConfigurationPacket config = ZeroFormatterSerializer.NonGeneric.Deserialize(
                typeof(ClientConfigurationPacket), data) as ClientConfigurationPacket;


        }
    }
}
