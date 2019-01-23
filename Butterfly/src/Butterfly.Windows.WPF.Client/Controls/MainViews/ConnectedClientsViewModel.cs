using Butterfly.Windows.WPF.Client.Abstractions.Snackbar;
using Butterfly.Windows.WPF.Client.Core.Client;
using Butterfly.Windows.WPF.Client.ViewModels;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.Controls.MainViews
{
    public class ConnectedClientsViewModel : BaseViewModel
    {
        public ConnectedClientsViewModel(IButterflyWPFClient networkClient,
            IEventAggregator eventAggregator,
            IRegionManager regionManager,
            ISnackbarController snackbarController)
            : base(networkClient, eventAggregator, regionManager, snackbarController)
        {

        }
    }
}
