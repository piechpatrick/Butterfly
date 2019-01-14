using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Windows.Audio.Players
{
    public class SimplePlayer
    {
        private static object syncRoot = new object();
        WaveOutEvent waveOut;
        List<byte[]> cache;
        public SimplePlayer()
        {
            waveOut = new WaveOutEvent();
        }


        public void StartPlay(MemoryStream ms, long position = 0)
        {
            try
            {
                long lastPosition = position;
                // Pre-buffering some data to allow NAudio to start playing
                while (ms.Length < 65536 * 5)
                    Thread.Sleep(1000);

                using (WaveStream blockAlignedStream = new BlockAlignReductionStream(
                    WaveFormatConversionStream.CreatePcmStream(
                    new RawSourceWaveStream(ms,new WaveFormat()))))
                {
                    blockAlignedStream.Position = position;
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        blockAlignedStream.Position = lastPosition;
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                        lastPosition = blockAlignedStream.Position;
                    }
                }

                this.StartPlay(ms,lastPosition);



            }
            catch (FileNotFoundException e)
            {
                // TODO
            }
            catch (IOException e)
            {
                // TODO
            }
        }

        public void Play(byte[] data)
        {
            lock (syncRoot)
            {
                if (this.FillCache(data))
                {

                    //this.StartPlay(data);
                }
            }
        }

        private bool FillCache(byte[] data)
        {
            if (cache == null)
                cache = new List<byte[]>();
            cache.Add(data);

            if (cache.Count < 20)
                return false;
            return true;
        }

    }
}
