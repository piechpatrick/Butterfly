using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.Core.Client
{
    public class ButterflyWPFClient : IButterflyWPFClient
    {
        private readonly INetworkClient networkClient;
        public ButterflyWPFClient(INetworkClient networkClient)
        {
            this.networkClient = networkClient;
        }

        public void Start()
        {
            this.networkClient.Connect();
        }
    }
}
