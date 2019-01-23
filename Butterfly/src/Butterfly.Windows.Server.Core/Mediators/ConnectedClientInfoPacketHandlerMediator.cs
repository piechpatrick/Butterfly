using Butterfly.MultiPlatform.Interfaces.Mediators;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.ViewModels;
using Butterfly.Windows.Server.Core.ConnectedClients;
using Butterfly.Windows.Server.Handlers.Server;
using Networker.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Core.Mediators
{
    public class ConnectedClientInfoPacketHandlerMediator : IConnectedClientInfoPacketHandlerMediator
    {
        private readonly IConnectedClients connectedClients;
        public ConnectedClientInfoPacketHandlerMediator(IConnectedClients connectedClients)
        {
            this.connectedClients = connectedClients;
        }


        public void Send(ConnectedClientInfoPacket message, IMediatable<ConnectedClientInfoPacket> mediatable)
        {
            var hasOne = this.connectedClients
                .GetAll()
                .Where(cc => cc.Connection.Socket == mediatable.Sender.Socket).FirstOrDefault();
            if(hasOne != null)
            {
                hasOne.Connection.Socket = mediatable.Sender.Socket;
                hasOne.IsAdmin = message.ConnectedClientViewModel.IsAdmin;
                hasOne.Name = message.ConnectedClientViewModel.Name;
                hasOne.Longitude = message.ConnectedClientViewModel.Longitude;
                hasOne.Latitude = message.ConnectedClientViewModel.Latitude;
            }
            else
                this.connectedClients.Add(new ConnectedClientViewModelServerSide()
                {
                    Connection = new TcpConnection(mediatable.Sender.Socket),
                    IsAdmin = message.ConnectedClientViewModel.IsAdmin,
                    Machine = message.ConnectedClientViewModel.Machine,
                    Name = message.ConnectedClientViewModel.Name
                });
        }
    }


}
