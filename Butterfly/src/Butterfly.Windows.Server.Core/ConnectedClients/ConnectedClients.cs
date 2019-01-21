using Butterfly.MultiPlatform.ViewModels;
using Butterfly.MultiPlatform.ViewModels.Identities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Core.ConnectedClients
{
    public class ConnectedClients : IConnectedClients
    {
        private List<IConnectedClientViewModelServerSide> connectedClientViewModels;
        public ConnectedClients()
        {
            this.connectedClientViewModels = new List<IConnectedClientViewModelServerSide>();
        }

        public void Add(IConnectedClientViewModelServerSide connectedClientViewModel)
        {
            this.connectedClientViewModels.Add(connectedClientViewModel);
        }

        public IEnumerator<IConnectedClientViewModelServerSide> GetEnumerator()
        {
            return this.connectedClientViewModels.GetEnumerator();
        }

        public void Remove(IConnectedClientViewModelServerSide connectedClientViewModel)
        {
            this.connectedClientViewModels.Remove(connectedClientViewModel);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.connectedClientViewModels.GetEnumerator();
        }
    }
}
