using Butterfly.MultiPlatform.Packets.Configuration;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.Common.Events
{
    public class ConnectedClientsPacketEvent : PubSubEvent<ConnectedClientsPacket>
    {
    }
}
