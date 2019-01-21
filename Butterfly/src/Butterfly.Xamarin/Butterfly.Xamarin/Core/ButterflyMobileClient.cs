using Butterfly.MultiPlatform.Handlers.Client;
using Butterfly.MultiPlatform.Interfaces.Services.Clients;
using Butterfly.MultiPlatform.Modules.HandlersModules;
using Butterfly.MultiPlatform.Packets.Pings;
using Networker.Client;
using Networker.Client.Abstractions;
using Networker.Formatter.ProtobufNet;
using Networker.Formatter.ZeroFormatter;
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
        }

        public void Start()
        {
            this.TryConnect();
        }

        private void HandleExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            //Handle Exceptions 
        }

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

                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        //client.Send(new PingPacket
                        //{
                        //    Text = "asdf"
                        //});

                        //this.networkClient.SendUdp(new PingPacket
                        //{
                        //    Text = "asdf"
                        //});

                        Thread.Sleep(5000);
                    }
                });
            }
            catch (Exception e)
            {
                Thread.Sleep(5000);
                this.TryConnect();
            }
        }
    }
}
