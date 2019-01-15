using Butterfly.MultiPlatform.Interfaces.Senders;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Senders.UDP
{
    public class GenericUDPPacketSender<TPacket> : IGenericPacketSender<TPacket>
    {
        private readonly INetworkClient client;
        public GenericUDPPacketSender(INetworkClient client)
        {
            this.client = client;
        }

        public void Send(TPacket packet)
        {
            this.client.SendUdp<TPacket>(packet);
        }
    }
}
