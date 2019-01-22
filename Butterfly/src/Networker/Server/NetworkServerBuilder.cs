using System;
using Butterfly.MultiPlatform.Intefaces.Audio;
using Microsoft.Extensions.DependencyInjection;
using Networker.Common.Abstractions;
using Networker.Server.Abstractions;

namespace Networker.Server
{
    public class NetworkServerBuilder : NetworkerBuilderBase<INetworkServerBuilder, INetworkServer, ServerBuilderOptions>, INetworkServerBuilder
    {
        private Type tcpSocketListenerFactory;
        private Type udpSocketListenerFactory;

        public NetworkServerBuilder() : base()
        {

        }

        public override INetworkServer Build()
        {
            serviceCollection.AddSingleton<INetworkServerBuilder>(this);
            this.SetupSharedDependencies();
            serviceCollection.AddSingleton<ITcpConnections, TcpConnections>();
            serviceCollection.AddSingleton<INetworkServer, NetworkServer>();
            serviceCollection.AddSingleton<IServerInformation, ServerInformation>();
            serviceCollection.AddSingleton<IServerPacketProcessor, ServerPacketProcessor>();
            serviceCollection.AddSingleton<IBufferManager>(new BufferManager(
                this.options.PacketSizeBuffer * this.options.TcpMaxConnections * 1,
                this.options.PacketSizeBuffer));


            if(this.tcpSocketListenerFactory == null)
                serviceCollection
                    .AddSingleton<ITcpSocketListenerFactory, DefaultTcpSocketListenerFactory>();

            if(this.udpSocketListenerFactory == null)
                serviceCollection
                    .AddSingleton<IUdpSocketListenerFactory, DefaultUdpSocketListenerFactory>();

            serviceCollection.AddSingleton<INetworkServerBuilder>(this);

            //return serviceProvider.GetService<INetworkServer>();
            return null;
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
            serviceCollection.AddSingleton<ITcpSocketListenerFactory, T>();
            return this;
        }

        public INetworkServerBuilder UseUdpSocketListener<T>()
            where T: class, IUdpSocketListenerFactory
        {
            this.udpSocketListenerFactory = typeof(T);
            serviceCollection.AddSingleton<IUdpSocketListenerFactory, T>();
            return this;
        }

        public INetworkServerBuilder RegiserUnionsModule<T>()
            where T : class
        {
            serviceCollection.AddSingleton<T>(Activator.CreateInstance<T>());
            return this;
        }
    }
}