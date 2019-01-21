using Butterfly.MultiPlatform.Packets.Pings;
using Butterfly.Windows.Server.Core.ConnectedClients;
using Butterfly.Windows.Server.Handlers.Server;
using Networker.Server.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Core.HandlerWrappers
{
    public class ConnectedClientInfoHandlerWrapper : IConnectedClientInfoHandlerWrapper
    {
        ConnectedClientInfoHandler connectedClientInfoHandler;
        IConnectedClients connectedClients;
        INetworkServer networkServer;
        public ConnectedClientInfoHandlerWrapper(IConnectedClients connectedClients, INetworkServer networkServer)
        {
            this.connectedClients = connectedClients;
            this.networkServer = networkServer;
        }

        public void Attach(ConnectedClientInfoHandler connectedClientInfoHandler)
        {
            this.connectedClientInfoHandler = connectedClientInfoHandler;
            this.connectedClientInfoHandler.Event += ConnectedClientInfoHandler_Event;
        }

        private void ConnectedClientInfoHandler_Event(object sender, ConnectedClientInfoEvetArgs e)
        {
            foreach (var connectedClient in connectedClients)
            {
                if(connectedClient.Connection.Socket.RemoteEndPoint == e.Sender.EndPoint)
                {
                    networkServer.Send<PingPacket>(new PingPacket(), connectedClient.Connection);
                }
            }
        }
    }
    public interface IConnectedClientInfoHandlerWrapper
    {
        void Attach(ConnectedClientInfoHandler connectedClientInfoHandler);
    }
}
