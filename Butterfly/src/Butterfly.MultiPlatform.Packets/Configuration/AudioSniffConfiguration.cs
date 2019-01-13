using Networker.Formatter.ProtobufNet;
using Networker.Formatter.ZeroFormatter;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Configuration
{
    [ZeroFormattable]
    public class AudioSniffConfigurationPacket : ZeroFormatterPacketBase
    {
        [Index(0)]
        public virtual bool CanRecive { get; set; }
    }
}
