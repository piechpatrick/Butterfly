using Butterfly.MultiPlatform.Intefaces.Audio;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Services.Audio
{
    public class RecorderService : IRecorderService
    {
        AudioRecorderBackroundWorker worker;
        public RecorderService(IClient client)
        {
            this.worker = new AudioRecorderBackroundWorker(client);
        }

        public bool IsRunning
        {
            get { return this.worker.IsRunning; }
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
