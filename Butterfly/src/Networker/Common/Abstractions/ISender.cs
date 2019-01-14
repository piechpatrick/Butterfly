using System;
using System.Net;
using System.Net.Sockets;

namespace Networker.Common.Abstractions
{
    public interface ISender
    {
        void Send<T>(T packet);
        EndPoint EndPoint { get; }
    }
}