using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.Server.Core.Server;
using Butterfly.Server.Services;
using Butterfly.Windows.Modules.Common;
using Butterfly.Windows.Server.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Networker.Server;
using Networker.Server.Abstractions;
using Networker.Formatter.ZeroFormatter;
using System;
using Butterfly.Windows.Server.Core.ConnectedClients;
using Butterfly.Windows.Modules.Server;
using Butterfly.Windows.Server.Core.HandlerWrappers;

namespace Butterfly.Windows.Server.Builders.Server
{
    public class ButterflyServerBuilder : BuilderBase<IButterflyServerBuilder, IButterflyServer, ButterflyServerOptions>, IButterflyServerBuilder
    {

        public ButterflyServerBuilder() : base()
        {

        }
        public override IButterflyServer Build()
        {
            this.serviceCollection.AddSingleton<IButterflyService, ButterflyService>();
            this.serviceCollection.AddSingleton<IButterflyServerBuilder>(this);

            ///network server instance
            var serverBuilder = new Networker.Server.NetworkServerBuilder().SetServiceCollection(this.GetServiceCollection());
            serverBuilder
                    .UseTcp(7894)
                    .UseUdp(7895)
                    .UseUdpSocketListener<DefaultUdpSocketListenerFactory>()
                                .SetMaximumConnections(100)
                                .ConfigureLogging(loggingBuilder =>
                                {
                                    loggingBuilder.SetMinimumLevel(
                                        LogLevel.Debug);
                                })
                                .RegisterPacketHandlerModule<PingPacketHandlerModule>()
                                .RegisterPacketHandlerModule<AudioPacketHandlerModule>()
                                .RegisterPacketHandlerModule<VideoPacketHandlerModule>()
                                .RegisterPacketHandlerModule<ConnectedClientHandlerModule>()
                                .UseZeroFormatter()
                                .SetPacketBufferSize(5000000)
                                .Build();


            this.serviceCollection.AddSingleton<IConnectedClients,ConnectedClients>();
            this.serviceCollection.AddSingleton<IConnectedClientInfoHandlerWrapper, ConnectedClientInfoHandlerWrapper>();
            this.serviceCollection.AddSingleton<IButterflyServer, ButterflyServer>();
            this.serviceCollection.AddSingleton<INetworkServer, NetworkServer>();
            serviceProvider = this.GetServiceProvider();
            serverBuilder.GetServiceProvider(serviceProvider);

            return serviceProvider.GetService<IButterflyServer>();
        }

        public IButterflyService GetButterflyService()
        {
            return this.serviceProvider?.GetService<IButterflyService>();
        }

        public override IServiceProvider GetServiceProvider(IServiceProvider serviceProvider = null)
        {
            return this.serviceProvider ?? serviceCollection.BuildServiceProvider();
        }
    }
}
