using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.Xamarin.Android.Services.IO.Audio.Workers;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Butterfly.Xamarin.Android.Services.IO.Audio
{
    //    [IntentFilter(new String[] { "com.companyname.Butterfly.MultiPlatform.Services.Audio.RecorderService" })]
    //    [Service(IsolatedProcess = true,
    //        Name = "com.companyname.Butterfly.MultiPlatform.Services.Audio.RecorderService",
    //        Process = ":recorderServiceProcess",
    //        Exported = true,
    //        Label = "Isolated Process service that has trouble starting",
    //        Icon = "@mipmap/icon"
    //        )]
    [Service(Name = "com.companyname.Butterfly.MultiPlatform.Services.Audio.RecorderService", Exported = true)]
    public class AudioRecorderService : Service, IRecorderService
    {

        static readonly int TimerWait = 5000;
        Timer timer;
        DateTime startTime;
        bool isStarted;
        int idx = 0;

        AudioRecorderBackroundWorker worker;
        public AudioRecorderService(INetworkClient client)
            : base()
        {
            this.worker = new AudioRecorderBackroundWorker(client);
        }

        public AudioRecorderService()
            : base()
        {
            //Toast.MakeText(this.ApplicationContext, "ctor", ToastLength.Long).Show();
            this.worker = new AudioRecorderBackroundWorker(Client);
            this.Start();
        }

        public static INetworkClient Client { get; set; }

        public static Context Context { get; set; }


        public bool IsRunning
        {
            get { return this.worker.IsRunning; }
        }

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            isStarted = true;
            //PlaySound();
            this.Start();
            return StartCommandResult.Sticky;
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            Intent bIntent = new Intent("com.companyname.Actions.ServiceStop");
            Context.SendBroadcast(bIntent);
            this.Stop();
        }

        public override void OnTaskRemoved(Intent rootIntent)
        {
            Intent bIntent = new Intent("com.companyname.Actions.ServiceStop");
            Context.SendBroadcast(bIntent);
            base.OnTaskRemoved(rootIntent);
        }

        public override bool OnUnbind(Intent intent)
        {
            return base.OnUnbind(intent);
        }

        public void OnRecived(byte[] audioBuffor)
        {

        }

        public void Start()
        {
            this.worker.Start();
        }

        public void Stop()
        {
            this.worker.Stop();
        }

    }
}
