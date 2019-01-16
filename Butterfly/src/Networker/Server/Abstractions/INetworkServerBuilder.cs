using Networker.Common.Abstractions;

namespace Networker.Server.Abstractions
{
    public interface INetworkServerBuilder : INetworkerBuilder<INetworkServerBuilder, INetworkServer>
    {
        //Tcp
        INetworkServerBuilder UseTcpSocketListener<T>()
            where T: class, ITcpSocketListenerFactory;

        //Udp
        INetworkServerBuilder UseUdpSocketListener<T>()
            where T: class, IUdpSocketListenerFactory;

        //Info
        INetworkServerBuilder SetMaximumConnections(int maxConnections);
    }
}