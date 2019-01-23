using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets
{
    [ZeroFormattable]
    public class PacketBase
    {
        [Index(0)]
        public virtual DateTime DateTime => DateTime.Now;
    }
}
