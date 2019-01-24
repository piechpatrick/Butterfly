using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Senders
{
    public interface IGenericPacketSender<TPacket>
    {
        void Send(TPacket packet);
    }
}
