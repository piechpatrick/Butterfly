using Microsoft.Extensions.DependencyInjection;
using Networker.Client.Abstractions;
using Networker.Common.Abstractions;

namespace Networker.Client
{
    public class NetworkClientBuilder : BuilderBase<INetworkClientBuilder, INetworkClient, ClientBuilderOptions>, INetworkClientBuilder
    {
        public NetworkClientBuilder() : base()
        {

        }

        public override INetworkClient Build()
        {
            this.SetupSharedDependencies();
            this.serviceCollection.AddSingleton<INetworkClient, NetworkClient>();
            this.serviceCollection.AddSingleton<IClientPacketProcessor, ClientPacketProcessor>();

            var serviceProvider = this.GetServiceProvider();

            return serviceProvider.GetService<INetworkClient>();
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