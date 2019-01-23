using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.MultiPlatform.Interfaces.Application;
using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.MultiPlatform.Interfaces.Services;
using Butterfly.MultiPlatform.Interfaces.Services.Clients;
using Butterfly.MultiPlatform.Interfaces.Services.Video;

namespace Butterfly.Xamarin.Core.Builders
{
    public interface IButterflyMobileClientBuilder : IBuilder<IButterflyMobileClientBuilder, IButterflyMobileClient>
    {
        IButterflyMobileClientBuilder SetGeolocalizationService<T>()
            where T : class, ILocalizationService;
        IButterflyMobileClientBuilder SetServiceController<T>()
            where T : class, IServiceController;

        IButterflyMobileClientBuilder SetConnectedClientInfoUpdaterService<T>()
            where T : class, IConnectedClientInfoUpdaterService;

        IButterflyMobileClientBuilder SetAudioRecorderService<T>()
            where T : class, IAudioRecorderService;

        IButterflyMobileClientBuilder SetCameraRecorderService<T>()
            where T : class, ICameraRecorderService;

        IButterflyMobileClientBuilder SetApplication<TApp>()
           where TApp : class, IApplication<TApp>;

        IButterflyMobileClientBuilder BuildNetworkClient();
    }
}
