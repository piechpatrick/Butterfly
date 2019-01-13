using System;
using System.Net.Sockets;
using Networker.Common.Abstractions;
using Networker.Server.Abstractions;

namespace Networker.Server
{
    public class TcpConnection : ITcpConnection
    {
        public TcpConnection()
        {
            
        }
        public Socket Socket { get; set; }

        public TcpConnection(Socket socket)
        {
            this.Socket = socket;
        }
    }
}