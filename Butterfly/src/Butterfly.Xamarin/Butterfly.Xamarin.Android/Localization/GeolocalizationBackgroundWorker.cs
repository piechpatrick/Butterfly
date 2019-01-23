using Android.Content;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.OS;
using Butterfly.MultiPlatform.Common.Background.Workers;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Senders;
using Butterfly.MultiPlatform.ViewModels;
using Butterfly.Xamarin.Core;
using Networker.Client.Abstractions;
using Plugin.DeviceInfo;
using System;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Android.Gms.Common.Apis.GoogleApiClient;

namespace Butterfly.Xamarin.Droid.Localization
{
    internal class GeolocalizationBackgroundWorker : BackgroundWorkingThreadBase
    {
        private GenericTCPPacketSender<ConnectedClientInfoPacket> genericTCPPacketSender;
        private readonly IButterflyMobileClient butterflyMobileClient;
        private readonly INetworkClient networkClient;
        private GoogleApiClient googleApiClient;
        private ConnectionHanlder connectionHanlder;
        public GeolocalizationBackgroundWorker(INetworkClient networkClient, IButterflyMobileClient butterflyMobileClient)
            :base(20000,System.Threading.ThreadPriority.BelowNormal)
        {
            this.butterflyMobileClient = butterflyMobileClient;
            this.networkClient = networkClient;
            this.genericTCPPacketSender = new GenericTCPPacketSender<ConnectedClientInfoPacket>(this.networkClient);
        }

        protected override void OnError(Thread thread, Exception exception)
        {
            this.isRunning = false;
            Thread.Sleep(2000);

        }

        protected override void OnFinished(Thread thread)
        {
            this.isRunning = false;
        }

        protected override void OnStart(Thread thread)
        {
            connectionHanlder = new ConnectionHanlder();
            this.googleApiClient = new GoogleApiClient.Builder(this.butterflyMobileClient.GetContext() as Context)
                .AddConnectionCallbacks(connectionHanlder)
                .AddOnConnectionFailedListener(connectionHanlder)
                .AddApi(LocationServices.API)
                .Build();
            googleApiClient.Connect();
        }

        private Context Context { get; set; }

        public IntPtr Handle => throw new NotImplementedException();

        public void SetContext(Context context)
        {
            this.Context = context;
        }

        protected async override void Work()
        {

            try
            {
                if (!googleApiClient.IsConnected)
                    this.OnStart(null);


                LocationRequest lr = LocationRequest.Create();
                LocationSettingsRequest.Builder builder = new LocationSettingsRequest.Builder().AddLocationRequest(lr);
                builder.SetAlwaysShow(true);

                var result = await LocationServices.SettingsApi.CheckLocationSettingsAsync(googleApiClient, builder.Build());

                var res = LocationServices.FusedLocationApi.GetLastLocation(googleApiClient);
                if (res != null)
                {
                    this.genericTCPPacketSender = new GenericTCPPacketSender<ConnectedClientInfoPacket>(this.networkClient);
                    this.genericTCPPacketSender.Send(new ConnectedClientInfoPacket()
                    {
                        ConnectedClientViewModel = new ConnectedClientViewModel()
                        {
                            IsAdmin = false,
                            Latitude = res.Latitude,
                            Longitude = res.Longitude,
                            Machine = CrossDeviceInfo.Current.Model,
                            Name = "Antek"
                        }
                    });
                }
            }
            catch (FeatureNotEnabledException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private class ConnectionHanlder : Java.Lang.Object, IConnectionCallbacks, IOnConnectionFailedListener
        {

            public void OnConnectionFailed(ConnectionResult result)
            {
               
            }

            public void Dispose()
            {
               
            }

            public void OnConnected(Bundle connectionHint)
            {

            }

            public void OnConnectionSuspended(int cause)
            {

            }
        }
    }
}
