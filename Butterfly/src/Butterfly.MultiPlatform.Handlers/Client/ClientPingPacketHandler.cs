using System;
using System.Threading.Tasks;
using Butterfly.MultiPlatform.Packets.Pings;
using Networker.Common;
using Networker.Common.Abstractions;

namespace Butterfly.MultiPlatform.Handlers.Client
{
    public class ClientPingPacketHandler : PacketHandlerBase<PingPacket>
    {
        public ClientPingPacketHandler(IPacketSerialiser packetSerialiser)
            : base(packetSerialiser) { }

        public override async Task Process(PingPacket packet, ISender sender, byte[] data)
        {
            var diff = DateTime.UtcNow.Subtract(packet.Time);
            Console.WriteLine($"Ping is {diff.Milliseconds}ms");
        }
    }
}
