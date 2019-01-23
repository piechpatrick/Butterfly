using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.MultiPlatform.Modules.Unions;
using Butterfly.Windows.Modules.Client;
using Butterfly.Windows.Server.Handlers.WPFClient;
using Butterfly.Windows.WPF.Client.Core.Client;
using Microsoft.Extensions.DependencyInjection;
using Networker.Client;
using Networker.Client.Abstractions;
using Networker.Formatter.ZeroFormatter;
using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Butterfly.Windows.WPF.Client.Builders
{
    public class ButterflyWPFClientBuilder : BuilderBase<IButterflyWPFClientBuilder, IButterflyWPFClient, ButterflyWPFClientOptions>, IButterflyWPFClientBuilder
    {
        private readonly IUnityContainer containerRegistry;
        public ButterflyWPFClientBuilder(IUnityContainer containerRegistry)
        {
            this.containerRegistry = containerRegistry;
        }

        public override IButterflyWPFClient Build()
        {
            this.RegisterViewModels();
            var networkClientBuilder = new NetworkClientBuilder();
            var services = networkClientBuilder.GetServiceCollection();

            services.AddSingleton<IEventAggregator>(this.containerRegistry.Resolve<IEventAggregator>());

                            networkClientBuilder.UseIp("87.206.204.123")
                                                .UseTcp(7894)
                                                //.UseUdp(7895, 7895)
                                                .RegiserUnionsModule<DefaultDynamicUnionsModule>()
                                                .RegisterPacketHandlerModule<WPFClientHandlerModule>()
                                                .UseZeroFormatter()
                                                .SetPacketBufferSize(2000000)
                                                .Build();
            var serviceProvider = networkClientBuilder.GetServiceProvider();
            var networkClient = serviceProvider.GetService<INetworkClient>();
            var videoPacketHandler = serviceProvider.GetService<WPFNv21VideoPacketHandler>();


            this.containerRegistry.RegisterInstance<WPFNv21VideoPacketHandler>(videoPacketHandler);
            this.containerRegistry.RegisterInstance<INetworkClient>(networkClient);
            this.containerRegistry.RegisterInstance<IButterflyWPFClient>(new ButterflyWPFClient(networkClient,
                this.containerRegistry.Resolve<IEventAggregator>()));

            return containerRegistry.Resolve<IButterflyWPFClient>();
        }

        public override IServiceProvider GetServiceProvider(IServiceProvider serviceProvider = null)
        {
            return this.serviceProviderFactory != null ? this.serviceProviderFactory.Invoke() : serviceCollection.BuildServiceProvider();
        }

        protected void RegisterViewModels()
        {
            this.serviceCollection.AddTransient<MainWindowViewModel>();
        }
    }
}
