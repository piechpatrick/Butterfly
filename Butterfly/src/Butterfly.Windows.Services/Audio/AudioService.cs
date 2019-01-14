using Butterfly.Windows.Audio.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Services.Audio
{
    public class AudioService
    {
        private SimplePlayer simplePlayer;
        public AudioService()
        {
            this.simplePlayer = new SimplePlayer();          
        }

        public void Play(MemoryStream memoryStream)
        {
            this.simplePlayer.StartPlay(memoryStream);
        }


    }
}
