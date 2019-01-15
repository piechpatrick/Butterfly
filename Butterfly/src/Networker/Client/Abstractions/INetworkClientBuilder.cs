using Networker.Common.Abstractions;

namespace Networker.Client.Abstractions
{
    public interface INetworkClientBuilder : IBuilder<INetworkClientBuilder, INetworkClient>
    {
        //Udp
        INetworkClientBuilder UseUdp(int port, int localPort);

        //Info
        INetworkClientBuilder SetPacketBufferPoolSize(int size);
        INetworkClientBuilder UseIp(string ip);
    }
}