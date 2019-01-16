using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.Windows.Modules.Client;
using Butterfly.Windows.WPF.Client.Core.Client;
using Butterfly.Windows.WPF.Client.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Networker.Client;
using Networker.Client.Abstractions;
using Networker.Formatter.ZeroFormatter;
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
            var networkClient = new NetworkClientBuilder().UseIp("87.206.204.123")
                                                .UseTcp(7894)
                                                .UseUdp(7895, 7895)
                                                .RegisterPacketHandlerModule<WPFClientHandlerModule>()
                                                .UseZeroFormatter()
                                                .SetPacketBufferSize(2000000)
                                                .Build();
            this.containerRegistry.RegisterInstance<INetworkClient>(networkClient);
            this.containerRegistry.RegisterInstance<IButterflyWPFClient>(new ButterflyWPFClient(networkClient));

            return containerRegistry.Resolve<IButterflyWPFClient>();
        }

        protected override IServiceProvider GetServiceProvider()
        {
            return this.serviceProviderFactory != null ? this.serviceProviderFactory.Invoke() : serviceCollection.BuildServiceProvider();
        }

        protected void RegisterViewModels()
        {
            this.serviceCollection.AddTransient<MainWindowViewModel>();
        }
    }
}
