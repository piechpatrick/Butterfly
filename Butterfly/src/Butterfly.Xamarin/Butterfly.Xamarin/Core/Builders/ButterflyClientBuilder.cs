using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.Xamarin.Core.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Xamarin.Core.Builders
{
    public class ButterflyClientBuilder
        : BuilderBase<IButterflyClientBuilder, IButterflyClient, AndroidButterflyClientOptions>, IButterflyClientBuilder
    {
        public override IButterflyClient Build()
        {
            throw new NotImplementedException();
        }

        protected override IServiceProvider GetServiceProvider()
        {
            throw new NotImplementedException();
        }
    }
}
