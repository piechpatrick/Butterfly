using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces
{
    public interface ISender
    {
        void Send<T>(T packet);
        EndPoint EndPoint { get; }

        Socket Socket { get; }
    }
}
