using Butterfly.MultiPlatform.Packets.Audio;
using Butterfly.Windows.Handlers.Audio;
using Networker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Modules.HandlersModules
{
    public class AudioPacketHandlerModule : PacketHandlerModuleBase
    {
        public AudioPacketHandlerModule()
        {
            this.AddPacketHandler<PCMPacket, PCMPacketHandler>();
        }
    }
}
