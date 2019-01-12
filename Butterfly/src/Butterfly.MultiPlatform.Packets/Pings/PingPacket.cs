using Networker.Formatter.ProtobufNet;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Packets.Pings
{
    [ProtoContract]
    public class PingPacket : ProtoBufPacketBase
    {
        [ProtoMember(2)]
        public virtual DateTime Time { get; set; }
    }
}
