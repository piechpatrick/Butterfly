using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Butterfly.MultiPlatform.Modules.HandlersModules;
using Butterfly.Xamarin.Android.Core;
using Butterfly.Xamarin.Core;
using Butterfly.Xamarin.Core.Builders;
using Microsoft.Extensions.DependencyInjection;
using Networker.Client;
using Networker.Common.Abstractions;

namespace Butterfly.Xamarin.Droid.Builders
{
    public class AndroidClientBuilder : ButterflyMobileClientBuilder<AndroidClientBuilderOptions>
    {
        public AndroidClientBuilder()
            :base()
        {

        }
        public override IButterflyMobileClient Build()
        {        
            this.serviceCollection.AddSingleton<IButterflyMobileClient, AndroidClient>();
            var handlers = GetServiceProvider().GetService<IPacketHandlers>();
            return this.GetServiceProvider().GetService<IButterflyMobileClient>();
        }

        protected override IServiceProvider GetServiceProvider()
        {
            return this.serviceProviderFactory != null ? this.serviceProviderFactory.Invoke() : serviceCollection.BuildServiceProvider();
        }
    }
}