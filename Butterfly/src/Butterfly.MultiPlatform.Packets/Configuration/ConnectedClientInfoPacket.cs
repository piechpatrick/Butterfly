using Butterfly.MultiPlatform.ViewModels;
using Butterfly.MultiPlatform.ViewModels.Identities;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.Packets.Configuration
{
    [ZeroFormattable]
    public class ConnectedClientInfoPacket 
    {
        public ConnectedClientInfoPacket()
        {

        }

        public ConnectedClientInfoPacket(ConnectedClientViewModel connectedClientViewModel)
        {
            this.ConnectedClientViewModel = connectedClientViewModel;
        }
        [Index(0)]
        public virtual ConnectedClientViewModel ConnectedClientViewModel  { get; set;}
    }
}
