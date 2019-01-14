using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Configuration
{
    [ZeroFormattable]
    public class ClientConfigurationPacket 
    {
        [Index(0)]
        public virtual AudioSniffConfigurationPacket AudioSniffConfig { get; set; }
    }
}
