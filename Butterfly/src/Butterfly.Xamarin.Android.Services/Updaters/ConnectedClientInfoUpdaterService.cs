using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Butterfly.MultiPlatform.Common.Background.Workers;
using Butterfly.MultiPlatform.Interfaces.Services.Clients;
using Butterfly.Xamarin.Core;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Butterfly.Xamarin.Android.Services.Updaters
{
    [Service(Name = "com.companyname.Butterfly.MultiPlatform.Services.Audio.ConnectedClientInfoUpdaterService", Exported = true)]
    public class ConnectedClientInfoUpdaterService : Service, IConnectedClientInfoUpdaterService
    {
        ConnectedClientInfoUpdaterBackgroundWorker connectedClientInfoUpdaterBackgroundWorker;
        public ConnectedClientInfoUpdaterService(INetworkClient client)
            :base()
        {
            this.connectedClientInfoUpdaterBackgroundWorker = new ConnectedClientInfoUpdaterBackgroundWorker(
                client);
        }

        public ConnectedClientInfoUpdaterService()
            :base()
        {

        }

        public bool IsRunning => throw new NotImplementedException();
        
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            this.Start();
            return StartCommandResult.Sticky;
        }

        public void Start()
        {
            //this.connectedClientInfoUpdaterBackgroundWorker.Start();
        }

        public void Stop()
        {
            this.connectedClientInfoUpdaterBackgroundWorker.Stop();
        }
    }


}
