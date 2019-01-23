using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Configuration
{
    [ZeroFormattable]
    public class ConnectedClientsPacket
    {
        [Index(0)]
        public virtual List<ConnectedClientInfoPacket> ConnectedClients { get; set; }
    }
}
