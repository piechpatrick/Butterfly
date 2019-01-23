using Butterfly.MultiPlatform.ViewModels;
using Butterfly.MultiPlatform.ViewModels.Identities;
using Networker.Server.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Core.ConnectedClients
{
    public interface IConnectedClients 
    {
        void Add(IConnectedClientViewModelServerSide connectedClientViewModel);
        void Remove(IConnectedClientViewModelServerSide connectedClientViewModel);
        IEnumerable<IConnectedClientViewModelServerSide> GetAll();
    }
}
