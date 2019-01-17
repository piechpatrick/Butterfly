using Butterfly.MultiPlatform.Packets.Pings;
using Butterfly.Windows.Handlers.WPFClient;
using Butterfly.Windows.WPF.Client.Core.Client;
using Butterfly.Windows.WPF.Client.ViewModels;
using Networker.Client.Abstractions;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Butterfly.Windows.WPF.Client
{
    public class MainWindowViewModel : ViewModelBase
    {       
        public MainWindowViewModel(IButterflyWPFClient wpfClient, INetworkClient netClient, WPFPingPacketHandler pingPacket)
            :base(wpfClient,netClient,pingPacket)
        {
            
            this.wpfClient.Start();

            
            this.ClickCommand = new DelegateCommand(this.Send);
            
        }

        public ICommand ClickCommand { get; private set; }

        private void Send()
        {
            this.networkClient.SendUdp<PingPacket>(new PingPacket());
        }
    }
}
