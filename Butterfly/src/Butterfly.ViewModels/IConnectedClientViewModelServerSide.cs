using Networker.Server.Abstractions;


namespace Butterfly.MultiPlatform.ViewModels
{
    public interface IConnectedClientViewModelServerSide : IConnectedClientViewModel
    {
        ITcpConnection Connection { get; set; }
    }
}
