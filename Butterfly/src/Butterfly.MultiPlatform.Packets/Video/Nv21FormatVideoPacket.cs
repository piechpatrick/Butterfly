using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Video
{
    [ZeroFormattable]
    public class Nv21FormatVideoPacket
    {
        [Index(0)]
        public virtual byte [] Data { get; set; }
        [Index(1)]
        public virtual bool IsPart { get; set; }
    }
}
