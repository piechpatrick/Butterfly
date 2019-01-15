using Butterfly.MultiPlatform.Interfaces.Senders;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Senders
{
    public class GenericTCPPacketSender<TPacket> : IGenericPacketSender<TPacket>
    {
        private readonly INetworkClient client;
        public GenericTCPPacketSender(INetworkClient client)
        {
            this.client = client;
        }

        public void Send(TPacket packet)
        {
            this.client.Send<TPacket>(packet);
        }
    }
}
