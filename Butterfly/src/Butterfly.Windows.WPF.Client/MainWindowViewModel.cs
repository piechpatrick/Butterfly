using Butterfly.Windows.WPF.Client.Core.Client;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client
{
    public class MainWindowViewModel
    {
        private readonly IButterflyWPFClient networkClient;

        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(IButterflyWPFClient networkClient)
        {
            this.networkClient = networkClient;
            this.networkClient.Start();
        }
    }
}
