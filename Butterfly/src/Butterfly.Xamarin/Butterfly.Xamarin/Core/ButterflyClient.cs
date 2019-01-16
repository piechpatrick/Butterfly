using Butterfly.MultiPlatform.Handlers.Client;
using Butterfly.MultiPlatform.Modules.HandlersModules;
using Butterfly.MultiPlatform.Packets.Pings;
using Butterfly.MultiPlatform.Services.Audio;
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
    public class ButterflyClient : IButterflyClient
    {
        private static ButterflyClient instance;
        public static ButterflyClient Instance
        {
            get
            {
                lock (instance)
                {
                    if (instance == null)
                        instance = new ButterflyClient();
                    return instance;
                }
            }
        }

        public INetworkClient NetworkClient { get; private set; }
        public ButterflyClient()
        {
            this.NetworkClient = new NetworkClientBuilder().UseIp("87.206.204.123")
                                                .UseTcp(7894)
                                                .UseUdp(7895, 7895)
                                                .RegisterPacketHandlerModule<DefaultPacketHandlerModule>()
                                                .UseZeroFormatter()
                                                .SetPacketBufferSize(2000000)
                                                .Build();
            this.TryConnect();

            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += HandleExceptions;
        }

        public void StartRecorderService()
        {
            //var service = new RecorderService(this.Client);
            //service.Start();
        }

        private void HandleExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            //Handle Exceptions 
        }

        private void TryConnect()
        {          
            try
            {
                this.NetworkClient.Connected += (sender, socket) =>
                {
                    Console.WriteLine(
                        $"Client has connected to {socket.RemoteEndPoint}");
                };

                this.NetworkClient.Disconnected += (sender, socket) =>
                {
                    Console.WriteLine(
                        $"Client has disconnected from {socket.RemoteEndPoint}");
                };

                this.NetworkClient.Connect();

                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        //client.Send(new PingPacket
                        //{
                        //    Text = "asdf"
                        //});

                        this.NetworkClient.SendUdp(new PingPacket
                        {
                            Text = "asdf"
                        });

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
