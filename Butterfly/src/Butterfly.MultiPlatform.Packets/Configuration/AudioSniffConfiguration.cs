using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Configuration
{
    [ZeroFormattable]
    public class AudioSniffConfigurationPacket 
    {
        [Index(1)]
        public virtual bool CanRecive { get; set; }
    }
}
