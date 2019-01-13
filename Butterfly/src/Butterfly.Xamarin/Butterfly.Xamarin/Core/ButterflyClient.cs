using Butterfly.MultiPlatform.Handlers.Client;
using Butterfly.MultiPlatform.Modules.HandlersModules;
using Butterfly.MultiPlatform.Packets.Pings;
using Networker.Client;
using Networker.Formatter.ProtobufNet;
using Networker.Formatter.ZeroFormatter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Xamarin.Core
{
    public class ButterflyClient
    {
        public ButterflyClient()
        {
            this.TryConnect();
        }

        private void TryConnect()
        {
            try
            {
                var client = new ClientBuilder().UseIp("87.206.204.123")
                                                .UseTcp(7894)
                                                .UseUdp(7895,7895)
                                                .RegisterPacketHandlerModule<DefaultPacketHandlerModule>()
                                                .UseZeroFormatter()
                                                .Build();

                client.Connected += (sender, socket) =>
                {
                    Console.WriteLine(
                        $"Client has connected to {socket.RemoteEndPoint}");
                };

                client.Disconnected += (sender, socket) =>
                {
                    Console.WriteLine(
                        $"Client has disconnected from {socket.RemoteEndPoint}");
                };

                client.Connect();

                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        client.Send(new PingPacket
                        {
                            Time = DateTime.UtcNow
                        });

                        //client.SendUdp(new PingPacket
                        //{
                        //    Time = DateTime.UtcNow
                        //});

                        Thread.Sleep(10);
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
