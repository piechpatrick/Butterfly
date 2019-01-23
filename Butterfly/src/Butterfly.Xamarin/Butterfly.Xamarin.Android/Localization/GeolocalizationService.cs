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
using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.MultiPlatform.Interfaces.Services;
using Butterfly.Xamarin.Core;
using Networker.Client.Abstractions;

namespace Butterfly.Xamarin.Droid.Localization
{
    [Service(Name = "com.companyname.Butterfly.MultiPlatform.Services.Localization.GeolocalizationService", Exported = true)]
    public class GeolocalizationService : Service, ILocalizationService
    {
        private GeolocalizationBackgroundWorker geolocalizationBackgroundWorker;
        private readonly IButterflyMobileClient butterflyMobileClient;
        public GeolocalizationService() { }

        public GeolocalizationService(INetworkClient client, 
            IButterflyMobileClient butterflyMobileClient)
            : base()
        {
            this.butterflyMobileClient = butterflyMobileClient;
            this.geolocalizationBackgroundWorker = new GeolocalizationBackgroundWorker(client, butterflyMobileClient);
        }

        public bool IsRunning => this.geolocalizationBackgroundWorker.IsRunning;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            return StartCommandResult.Sticky;
        }

        public void Start()
        {
            this.geolocalizationBackgroundWorker.Start();
        }

        public void Stop()
        {
            this.geolocalizationBackgroundWorker.Stop();
        }
    }
}