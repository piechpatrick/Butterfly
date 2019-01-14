using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Configuration
{
    [ZeroFormattable]
    public class GetAudioPacket
    {
        [Index(0)]
        public virtual bool Active { get; set; }
    }
}
