
using Networker.Server.Abstractions;

namespace Butterfly.MultiPlatform.ViewModels
{
    public class ConnectedClientViewModelServerSide : ConnectedClientViewModel, IConnectedClientViewModelServerSide
    {
        public ConnectedClientViewModelServerSide()
            :base()
        {

        }

        public ITcpConnection Connection { get; set; }
    }
}
