using Butterfly.MultiPlatform.ViewModels;
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
        ConnectedClientViewModel selectedClientViewModel;
        string locationUrl = "https://www.google.com/maps";
        public ConnectedClientsViewModel(IButterflyWPFClient networkClient,
            IEventAggregator eventAggregator,
            IRegionManager regionManager,
            ISnackbarController snackbarController)
            : base(networkClient, eventAggregator, regionManager, snackbarController)
        {
            //regionManager.RequestNavigate("GMapRegion", "GMapUserControl");
        }

        public ConnectedClientViewModel SelectedClientViewModel
        {
            get { return this.selectedClientViewModel; }
            set
            {
                if (value != null)
                {
                    this.SetProperty(ref this.selectedClientViewModel, value);
                    this.LocationUrl = $"https://www.google.com/maps/place/{value.Longitude}, {value.Latitude}";
                }
            }
        }

        public string LocationUrl
        {
            get { return this.locationUrl; }
            set { this.SetProperty(ref this.locationUrl, value, "LocationUrl"); }
        }
    }
}
