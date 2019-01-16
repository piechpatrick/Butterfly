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

            ///network server instance
            var networkServer = new Networker.Server.NetworkServerBuilder()
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
                                .UseZeroFormatter()
                                .SetPacketBufferSize(2000000)
                                .Build();
            this.serviceCollection.AddSingleton<INetworkServer>(networkServer);
            this.serviceCollection.AddSingleton<IButterflyServer>(new ButterflyServer(this.serviceCollection,networkServer));

            var serviceProvider = this.GetServiceProvider();
            return serviceProvider.GetService<IButterflyServer>();
        }

        public IButterflyService GetButterflyService()
        {
            return this.GetServiceProvider().GetService<IButterflyService>();
        }

        protected override IServiceProvider GetServiceProvider()
        {
            return  this.serviceProviderFactory != null ? this.serviceProviderFactory.Invoke() : serviceCollection.BuildServiceProvider();
        }
    }
}
