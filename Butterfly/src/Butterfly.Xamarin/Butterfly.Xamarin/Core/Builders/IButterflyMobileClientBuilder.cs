using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.MultiPlatform.Interfaces.Application;
using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.MultiPlatform.Interfaces.Services.Video;
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
            where T : class, IAudioRecorderService;

        IButterflyMobileClientBuilder SetCameraRecorderService<T>()
            where T : class, ICameraRecorderService;

        IButterflyMobileClientBuilder SetApplication<TApp>()
           where TApp : class, IApplication<TApp>;

        IButterflyMobileClientBuilder BuildNetworkClient();
    }
}
