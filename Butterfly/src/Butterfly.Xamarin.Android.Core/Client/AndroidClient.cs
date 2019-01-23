using Butterfly.MultiPlatform.Interfaces.Services.Clients;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.Xamarin.Core;
using Microsoft.Extensions.Logging;
using Networker.Client.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Xamarin.Android.Core
{
    public class AndroidClient : ButterflyMobileClient
    {
        private readonly INetworkClient networkClient;
        private readonly IConnectedClientInfoUpdaterService connectedClientInfoUpdaterService;
        private readonly ILogger<AndroidClient> logger;
        public AndroidClient(INetworkClient networkClient, 
            IConnectedClientInfoUpdaterService connectedClientInfoUpdaterService,
            ILogger<AndroidClient> logger)
            :base(networkClient, connectedClientInfoUpdaterService)
        {
            this.networkClient = networkClient;
            this.connectedClientInfoUpdaterService = connectedClientInfoUpdaterService;
            this.logger = logger;
        }

        public override void PublishSelfInfo()
        {
            try
            {
                connectedClientInfoUpdaterService.Start();
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex, $"{nameof(this.PublishSelfInfo)}", "");
                connectedClientInfoUpdaterService.Start();
            }
            
        }
    }
}