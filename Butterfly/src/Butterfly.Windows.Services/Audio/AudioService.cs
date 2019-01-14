using Butterfly.MultiPlatform.Common.Background.Workers;
using Butterfly.MultiPlatform.Common.ObjectPool;
using Butterfly.MultiPlatform.Packets.Audio;
using Butterfly.Windows.Audio.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Windows.Services.Audio
{
    public class AudioService : BackgroundWorkingThreadBase
    {

        private Semaphore syncPlay = new Semaphore(1,1);
        private Semaphore syncCreate = new Semaphore(1, 1);

        private readonly ObjectPool<MemoryStream> memoryStreamsPool; 
        private SimplePlayer simplePlayer;
        private MemoryStream actualMemoryStream;
        public AudioService()
            :base(1,ThreadPriority.AboveNormal)
        {
            this.simplePlayer = new SimplePlayer();
            this.memoryStreamsPool = new ObjectPool<MemoryStream>(2);
            for (int i = 0; i < 2; i++)            
                this.memoryStreamsPool.Push(new MemoryStream());
            this.actualMemoryStream = this.memoryStreamsPool.Pop();
        }

        public void Fill(PCMPacket audioFrame)
        {
            lock (this.syncCreate)
            {
                this.actualMemoryStream.Write(audioFrame.Data, 0, audioFrame.Data.Length);
            }
        }

        protected override void OnError(Thread thread, Exception exception)
        {
            
        }

        protected override void OnFinished(Thread thread)
        {
            
        }

        protected override void OnStart(Thread thread)
        {
            
        }

        protected override void Work()
        {
            if (this.actualMemoryStream.Length < 128000)
                return;           
            var playable = new MemoryStream(this.actualMemoryStream.ToArray());
            this.CreateNew();
            lock (this.syncPlay)
            {
                this.simplePlayer.StartPlay(playable);
            }
        }

        private void CreateNew()
        {
            lock (this.syncCreate)
            {
                this.actualMemoryStream = new MemoryStream();
            }
        }
    }
}
