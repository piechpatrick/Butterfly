using System;
using Butterfly.MultiPlatform.Intefaces.Audio;
using Microsoft.Extensions.DependencyInjection;
using Networker.Common.Abstractions;
using Networker.Server.Abstractions;

namespace Networker.Server
{
    public class NetworkServerBuilder : BuilderBase<INetworkServerBuilder, INetworkServer, ServerBuilderOptions>, INetworkServerBuilder
    {
        private Type tcpSocketListenerFactory;
        private Type udpSocketListenerFactory;

        public NetworkServerBuilder() : base()
        {

        }

        public override INetworkServer Build()
        {
            this.SetupSharedDependencies();

            this.serviceCollection.AddSingleton<ITcpConnections, TcpConnections>();
            this.serviceCollection.AddSingleton<INetworkServer, NetworkServer>();
            this.serviceCollection.AddSingleton<IServerInformation, ServerInformation>();
            this.serviceCollection.AddSingleton<IServerPacketProcessor, ServerPacketProcessor>();
            this.serviceCollection.AddSingleton<IBufferManager>(new BufferManager(
                this.options.PacketSizeBuffer * this.options.TcpMaxConnections * 1,
                this.options.PacketSizeBuffer));


            if(this.tcpSocketListenerFactory == null)
                this.serviceCollection
                    .AddSingleton<ITcpSocketListenerFactory, DefaultTcpSocketListenerFactory>();

            if(this.udpSocketListenerFactory == null)
                this.serviceCollection
                    .AddSingleton<IUdpSocketListenerFactory, DefaultUdpSocketListenerFactory>();


            var serviceProvider = this.GetServiceProvider();

            return serviceProvider.GetService<INetworkServer>();
        }

        public INetworkServerBuilder SetMaximumConnections(int maxConnections)
        {
            this.options.TcpMaxConnections = maxConnections;
            return this;
        }

        public INetworkServerBuilder UseTcpSocketListener<T>()
            where T: class, ITcpSocketListenerFactory
        {
            this.tcpSocketListenerFactory = typeof(T);
            this.serviceCollection.AddSingleton<ITcpSocketListenerFactory, T>();
            return this;
        }

        public INetworkServerBuilder UseUdpSocketListener<T>()
            where T: class, IUdpSocketListenerFactory
        {
            this.udpSocketListenerFactory = typeof(T);
            this.serviceCollection.AddSingleton<IUdpSocketListenerFactory, T>();
            return this;
        }
    }
}