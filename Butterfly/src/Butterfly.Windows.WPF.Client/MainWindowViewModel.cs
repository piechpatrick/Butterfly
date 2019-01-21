using Butterfly.MultiPlatform.Packets.Video;
using Butterfly.Windows.Server.Handlers.WPFClient;
using Butterfly.Windows.WPF.Client.Core.Client;
using Butterfly.Windows.WPF.Client.Core.Events;
using Butterfly.Windows.WPF.Client.Core.HandlerWrappers.Video;
using Butterfly.Windows.WPF.Client.ViewModels;
using Networker.Client.Abstractions;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
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

        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(IButterflyWPFClient networkClient, 
            WPFNv21VideoPacketHandler nv21PacketHandler, 
            INv21PacketHandlerWrapper nv21PacketHandlerWrapper,
            IEventAggregator eventAggregator)
            :base(networkClient,nv21PacketHandler,nv21PacketHandlerWrapper,eventAggregator)
        {
            
        }
    }
}
