using Butterfly.MultiPlatform.Interfaces.Services.Clients;
using Butterfly.Xamarin.Core;
using Networker.Client.Abstractions;

namespace Butterfly.Xamarin.Android.Core
{
    public class AndroidClient : ButterflyMobileClient
    {
        public AndroidClient(INetworkClient networkClient, IConnectedClientInfoUpdaterService connectedClientInfoUpdaterService)
            :base(networkClient, connectedClientInfoUpdaterService)
        {

        }
    }
}