using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.MultiPlatform.Interfaces.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Xamarin.Core.Builders
{
    public interface IButterflyMobileClientBuilder : IBuilder<IButterflyMobileClientBuilder, IButterflyMobileClient>
    {
        IButterflyMobileClientBuilder SetServiceController<T>()
            where T : class, IServiceController;

        IButterflyMobileClientBuilder SetAudioRecorderService<T>()
            where T : class, IRecorderService;

        IButterflyMobileClientBuilder BuildNetworkClient();
    }
}
