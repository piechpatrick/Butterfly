using Butterfly.MultiPlatform.Packets.Video;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.Core.Events
{
    public class VideoFrameEvent : PubSubEvent<Nv21FormatVideoPacket> 
    {
    }
}
