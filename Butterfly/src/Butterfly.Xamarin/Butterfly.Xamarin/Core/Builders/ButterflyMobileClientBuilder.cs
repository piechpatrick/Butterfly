using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.MultiPlatform.Interfaces.Services;
using Butterfly.MultiPlatform.Modules.HandlersModules;
using Microsoft.Extensions.DependencyInjection;
using Networker.Client;
using Networker.Formatter.ZeroFormatter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Xamarin.Core.Builders
{
    public abstract class ButterflyMobileClientBuilder<TBuilderOptions>
        : BuilderBase<IButterflyMobileClientBuilder, IButterflyMobileClient, TBuilderOptions>, IButterflyMobileClientBuilder
         where TBuilderOptions : class, IButterflyMobileClientBuilderOptions

    {
        public ButterflyMobileClientBuilder()
            :base()
        {

           
        }

        public virtual IButterflyMobileClientBuilder BuildNetworkClient()
        {
            var builderNetwork = new NetworkClientBuilder().SetServiceCollection(this.GetServiceCollection());
            builderNetwork.UseIp("87.206.204.123")
                       .UseTcp(7894)
                       .UseUdp(7895, 7895)
                       .RegisterPacketHandlerModule<DefaultPacketHandlerModule>()
                       .UseZeroFormatter()
                       .SetPacketBufferSize(2000000)
                       .Build();
            return this;
        }

        public virtual IButterflyMobileClientBuilder SetAudioRecorderService<T>()
            where T : class, IRecorderService
        {
            this.serviceCollection.AddSingleton<IRecorderService, T>();
            return this;
        }

        public virtual IButterflyMobileClientBuilder SetServiceController<T>()
            where T : class, IServiceController
        {
            this.serviceCollection.AddSingleton<IServiceController, T>();
            return this;
        }
    }
}
