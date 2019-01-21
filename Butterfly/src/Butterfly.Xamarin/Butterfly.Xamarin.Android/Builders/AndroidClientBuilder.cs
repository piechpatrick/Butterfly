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
using Networker.Client.Abstractions;
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
            return this.GetServiceProvider().GetService<IButterflyMobileClient>();
        }

        public override IServiceProvider GetServiceProvider(IServiceProvider serviceProvider = null)
        {
            var builtServiceProvider =  serviceCollection.BuildServiceProvider();
            var networkClientBuilder = builtServiceProvider.GetService<INetworkClientBuilder>();
            return networkClientBuilder.GetServiceProvider(builtServiceProvider);           
        }
    }
}