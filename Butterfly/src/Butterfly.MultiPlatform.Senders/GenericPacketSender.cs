using Butterfly.MultiPlatform.Interfaces.Senders;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Senders
{
    public class GenericPacketSender<TPacket> : IGenericPacketSender<TPacket>
    {
        private readonly IClient client;
        public GenericPacketSender(IClient client)
        {
            this.client = client;
        }

        public void Send(TPacket packet)
        {
            this.client.Send<TPacket>(packet);
        }
    }
}
