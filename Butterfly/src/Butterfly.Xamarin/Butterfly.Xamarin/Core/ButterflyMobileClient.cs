using Android.Content;
using Butterfly.MultiPlatform.Handlers.Client;
using Butterfly.MultiPlatform.Interfaces.Services.Clients;
using Butterfly.MultiPlatform.Modules.HandlersModules;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Packets.Pings;
using Butterfly.MultiPlatform.ViewModels;
using Networker.Client;
using Networker.Client.Abstractions;
using Networker.Formatter.ProtobufNet;
using Networker.Formatter.ZeroFormatter;
using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Xamarin.Core
{
    public abstract class ButterflyMobileClient : IButterflyMobileClient
    {

        private readonly INetworkClient networkClient;
        private readonly IConnectedClientInfoUpdaterService connectedClientInfoUpdaterService;
        public ButterflyMobileClient(INetworkClient networkClient, 
            IConnectedClientInfoUpdaterService connectedClientInfoUpdaterService)
        {
            this.networkClient = networkClient;
            this.connectedClientInfoUpdaterService = connectedClientInfoUpdaterService;
            this.ClientViewModel = new ConnectedClientViewModel()
            {
                IsAdmin = false,
                Machine = CrossDeviceInfo.Current.Model,
                Name = ".. android"
            };
        }

        public abstract void PublishSelfInfo();

        public void Start()
        {
            this.TryConnect();
        }

        private void HandleExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            //Handle Exceptions 
        }

        public IConnectedClientViewModel ClientViewModel { get;  set; }

        private void TryConnect()
        {          
            try
            {
                this.networkClient.Connected += (sender, socket) =>
                {
                    Console.WriteLine(
                        $"Client has connected to {socket.RemoteEndPoint}");
                    this.connectedClientInfoUpdaterService.Start();
                };

                this.networkClient.Disconnected += (sender, socket) =>
                {
                    Console.WriteLine(
                        $"Client has disconnected from {socket.RemoteEndPoint}");
                    this.connectedClientInfoUpdaterService.Stop();
                };

                this.networkClient.Connect();           
            }
            catch (Exception e)
            {
                Thread.Sleep(5000);
                this.TryConnect();
            }
        }

        protected Context Context { get; private set; }
        public void SetContext(object context)
        {
            this.Context = context as Context;
        }

        public object GetContext()
        {
            return this.Context;
        }
    }
}
