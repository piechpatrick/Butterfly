using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Audio
{
    [ZeroFormattable]
    public class PCMPacket 
    {
        [Index(0)]
        public virtual byte[] Data { get; set; }
    }
}
