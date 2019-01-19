using Android.Media;
using Butterfly.MultiPlatform.Common.Background.Workers;
using Butterfly.MultiPlatform.Senders;
using Butterfly.MultiPlatform.Senders.UDP;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Encoding = Android.Media.Encoding;

namespace Butterfly.Android.Services.IO.Audio.Workers
{
    internal class AudioRecorderBackroundWorker : BackgroundWorkingThreadBase
    {
        private int bufferSize;
        private AudioRecord recorder;
        private readonly INetworkClient client;
        private GenericUDPPacketSender<MultiPlatform.Packets.Audio.PCMPacket> pcmSender;

        public AudioRecorderBackroundWorker(INetworkClient client)
            : base(1, ThreadPriority.AboveNormal)
        {
            this.client = client;
            this.pcmSender = new GenericUDPPacketSender<MultiPlatform.Packets.Audio.PCMPacket>(this.client);         
        }

        protected override void OnError(Thread thread, Exception exception)
        {

        }

        protected override void OnFinished(Thread thread)
        {

        }

        protected override void OnStart(Thread thread)
        {

            TaskScheduler syncContextScheduler;
            if (SynchronizationContext.Current != null)
            {
                syncContextScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            }
            else
            {
                // If there is no SyncContext for this thread (e.g. we are in a unit test
                // or console scenario instead of running in an app), then just use the
                // default scheduler because there is no UI thread to sync with.
                syncContextScheduler = TaskScheduler.Current;
            }

            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {

                    var location = await Geolocation.GetLocationAsync();
                        if (location != null)
                            Console.WriteLine("Localização", $"latitude:{location.Latitude}, logintude:{location.Longitude}", "OK");
                });
            }
            catch(FeatureNotEnabledException ex)
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }



            this.bufferSize = AudioRecord.GetMinBufferSize(44100, ChannelIn.Default, Encoding.Pcm16bit);
            this.recorder = new AudioRecord(AudioSource.Mic, 44100, ChannelIn.Mono, Encoding.Pcm16bit, bufferSize);
            this.recorder.StartRecording();

        }

        protected override void Work()
        {           
            while (recorder == null || recorder.State == State.Uninitialized)
            {
                Thread.Sleep(100);
            }
            var buffor = new byte[bufferSize];
            var audioSize = recorder.Read(buffor, 0, bufferSize);
            if (audioSize > 0)
            {
                pcmSender.Send(new MultiPlatform.Packets.Audio.PCMPacket() { Data = buffor });
                Thread.Sleep(1);
            }
        }
    }
}
