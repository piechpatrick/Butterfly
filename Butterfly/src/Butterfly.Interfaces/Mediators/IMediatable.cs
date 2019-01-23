using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Mediators
{
    public interface IMediatable<TMessage>
        where TMessage : class
    {
        ISender Sender { get; set; }
        void Send(TMessage message);
    }
}
