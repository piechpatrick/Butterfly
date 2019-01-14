using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Pings
{
    [ZeroFormattable]
    public class PingPacket 
    {
        [Index(1)]
        public virtual string Text { get; set; }
    }
}
