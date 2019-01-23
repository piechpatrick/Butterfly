using Butterfly.MultiPlatform.ViewModels;
using Butterfly.Windows.Server.Core.ConnectedClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Core.Services
{
    public class ConnectedUsersService
    {
        private readonly static object syncRoot = new object();

        private readonly IConnectedClients connectedClients;
        public ConnectedUsersService(IConnectedClients connectedClients)
        {
            this.connectedClients = connectedClients;
        }

        IEnumerable<IConnectedClientViewModelServerSide> GetAll()
        {
            lock(syncRoot)
            {
                return this.connectedClients.GetAll();
            }
        }
    }
}
