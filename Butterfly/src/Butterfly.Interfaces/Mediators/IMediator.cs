using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Mediators
{

    public interface IMediator<TMessage>
        where TMessage : class
    {
        void Send(TMessage message, IMediatable<TMessage> mediatable);
    }
}
