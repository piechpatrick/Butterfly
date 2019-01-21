using Networker.Common.Abstractions;
using System;

namespace Networker.Client.Abstractions
{
    public interface INetworkClientBuilder : INetworkerBuilder<INetworkClientBuilder, INetworkClient>
    {
        //Udp
        INetworkClientBuilder UseUdp(int port, int localPort);

        //Info
        INetworkClientBuilder SetPacketBufferPoolSize(int size);
        INetworkClientBuilder UseIp(string ip);    
    }
}