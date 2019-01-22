using Butterfly.MultiPlatform.Packets.Video;
using Butterfly.Windows.Server.Handlers.WPFClient;
using Butterfly.Windows.WPF.Client.Abstractions.Snackbar;
using Butterfly.Windows.WPF.Client.Controls.MainViews;
using Butterfly.Windows.WPF.Client.Core.Client;
using Butterfly.Windows.WPF.Client.Core.Events;
using Butterfly.Windows.WPF.Client.Core.HandlerWrappers.Video;
using Butterfly.Windows.WPF.Client.MenuItems;
using Butterfly.Windows.WPF.Client.ViewModels;
using Networker.Client.Abstractions;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Butterfly.Windows.WPF.Client
{
    public class MainWindowViewModel : BaseViewModel 
    {
        private ObservableCollection<MenuItem> menuItems;
        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(IButterflyWPFClient networkClient, 
            WPFNv21VideoPacketHandler nv21PacketHandler, 
            INv21PacketHandlerWrapper nv21PacketHandlerWrapper,
            IEventAggregator eventAggregator,
            IRegionManager regionManager,
            ISnackbarController snackbarController)
            :base(networkClient,nv21PacketHandler,nv21PacketHandlerWrapper,eventAggregator,regionManager,snackbarController)
        {
            this.SetupMenuItems();   
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return this.menuItems; }
            set { this.SetProperty(ref menuItems, value); }
        }

        private void SetupMenuItems()
        {
            this.MenuItems = new ObservableCollection<MenuItem>()
            {
                new MenuItem("Homepage",new Home())
            };
        }
    }
}
