using Butterfly.MultiPlatform.ViewModels;
using Butterfly.MultiPlatform.ViewModels.Identities;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Configuration
{
    [ZeroFormattable]
    public class ConnectedClientInfoPacket
    {
        [Index(0)]
        public virtual ConnectedClientViewModel ConnectedClientViewModel  { get; set;}
    }
}
