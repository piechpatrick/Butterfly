using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Server
{
    public class Player
    {

        WaveOut waveout;
        int counter;
        BufferedWaveProvider bufferedWaveProvider;

        public Player()
        {
            waveout = new WaveOut();
            counter = 0;
            bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat(44100, 16, 1));
            bufferedWaveProvider.BufferLength = 3584 * 16;      //16 is pretty good
            bufferedWaveProvider.DiscardOnBufferOverflow = true;
        }
        public void StartClient(byte[] array)
        {
            try
            {
                //wait until buffer has data, then returns buffer length
                int bytesAvailable = array.Length;

                //send to speakers

                bufferedWaveProvider.AddSamples(array, 0, 3584);

                waveout.Init(bufferedWaveProvider);
                waveout.Play();         
                
            }
            catch (Exception e)
            {
            }
        }
    }
}
