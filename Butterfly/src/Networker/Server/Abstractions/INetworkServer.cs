﻿using System;
using Networker.Common;

namespace Networker.Server.Abstractions
{
    public interface INetworkServer
    {
        void Start();
        void Stop();
        ITcpConnections GetConnections();
        EventHandler<ServerInformationEventArgs> ServerInformationUpdated { get; set; }
        EventHandler<TcpConnectionConnectedEventArgs> ClientConnected { get; set; }
        EventHandler<TcpConnectionDisconnectedEventArgs> ClientDisconnected { get; set; }
        void Broadcast<T>(T packet);
        void SendToAllTCP<T>(T packet);
        void Send<T>(T packet, ITcpConnection tcpConnection);
    }
}