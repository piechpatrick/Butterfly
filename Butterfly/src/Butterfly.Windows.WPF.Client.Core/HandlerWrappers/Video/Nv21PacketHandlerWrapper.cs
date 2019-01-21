using Butterfly.Windows.Server.Handlers.Video;
using Butterfly.Windows.Server.Handlers.WPFClient;
using Butterfly.Windows.WPF.Client.Core.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.Core.HandlerWrappers.Video
{
    public class Nv21PacketHandlerWrapper : INv21PacketHandlerWrapper
    {
        private WPFNv21VideoPacketHandler nv21PacketHandler;
        private readonly IEventAggregator eventAggregator;
        public Nv21PacketHandlerWrapper(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void Attach(WPFNv21VideoPacketHandler wPFNv21VideoPacketHandler)
        {
            this.nv21PacketHandler = wPFNv21VideoPacketHandler;
            this.nv21PacketHandler.Event += this.Nv21PacketHandler_Event;
        }

        private void Nv21PacketHandler_Event(object sender, MultiPlatform.Packets.Video.Nv21FormatVideoPacket e)
        {
            this.eventAggregator.GetEvent<VideoFrameEvent>().Publish(e);
        }
    }
    public interface INv21PacketHandlerWrapper
    {
        void Attach(WPFNv21VideoPacketHandler wPFNv21VideoPacketHandler);
    }
}
