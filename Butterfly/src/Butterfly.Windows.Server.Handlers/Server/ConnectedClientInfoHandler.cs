using Butterfly.MultiPlatform.Packets.Configuration;
using Networker.Common;
using Networker.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Handlers.Server
{
    public class ConnectedClientInfoHandler : PacketHandlerBase<ConnectedClientInfoPacket>
    {
        public ConnectedClientInfoHandler()
        {

        }
        public override Task Process(ConnectedClientInfoPacket packet, ISender sender)
        {
            return Task.Factory.StartNew(() =>
            {
                this.OnFrameGot(packet, sender);
            });
        }

        protected virtual void OnFrameGot(ConnectedClientInfoPacket e, ISender sender)
        {
            EventHandler<ConnectedClientInfoEvetArgs> handler = Event;
            if (handler != null)
            {
                handler(this, new ConnectedClientInfoEvetArgs() { ClientInfo = e, Sender = sender });
            }
        }

        public event EventHandler<ConnectedClientInfoEvetArgs> Event;
    }

    public class ConnectedClientInfoEvetArgs : EventArgs
    {
        public ConnectedClientInfoPacket ClientInfo { get; set; }
        public ISender Sender { get; set; }
        public ConnectedClientInfoEvetArgs()
        {

        }
    }
}
