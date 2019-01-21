using Microsoft.Extensions.DependencyInjection;
using Networker.Client.Abstractions;
using Networker.Common.Abstractions;

namespace Networker.Client
{
    public class NetworkClientBuilder : NetworkerBuilderBase<INetworkClientBuilder, INetworkClient, ClientBuilderOptions>, INetworkClientBuilder
    {
        public NetworkClientBuilder() : base()
        {

        }

        public override INetworkClient Build()
        {
            serviceCollection.AddSingleton<INetworkClientBuilder>(this);
            this.SetupSharedDependencies();
            serviceCollection.AddSingleton<IClientPacketProcessor, ClientPacketProcessor>();
            serviceCollection.AddSingleton<INetworkClient, NetworkClient>();

            //var serviceProvider = this.GetServiceProvider();

            //return serviceProvider.GetService<INetworkClient>();
            return null;
        }

        public INetworkClientBuilder SetPacketBufferPoolSize(int size)
        {
            this.options.ObjectPoolSize = size;
            return this;
        }

        public INetworkClientBuilder UseIp(string ip)
        {
            this.options.Ip = ip;
            return this;
        }

        public INetworkClientBuilder UseUdp(int port, int localPort)
        {
            this.options.UdpPort = port;
            this.options.UdpPortLocal = localPort;
            return this;
        }
    }
}