using Butterfly.Maps.Entities;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Packets.Pings;
using Butterfly.Windows.Modules.HandlersModules;
using Microsoft.Extensions.Logging;
using Networker.Formatter.ProtobufNet;
using Networker.Formatter.ZeroFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Server.Core.Instances
{
    public class ButterflyServer : IButterflyServer
    {
        private bool run;


        public Networker.Server.Abstractions.IServer NetworkServer { get; private set; }

        public ButterflyServer()
        {

        }
        public void Start()
        {
            try
            {
                int threadsCount, k;
                ThreadPool.GetMaxThreads(out threadsCount, out k);

                this.NetworkServer = new Networker.Server.ServerBuilder()
                    .UseTcp(7894)
                     .UseUdp(7895)                                                   
                                .SetMaximumConnections(1)
                                .ConfigureLogging(loggingBuilder =>
                                {
                                    loggingBuilder.SetMinimumLevel(
                                        LogLevel.Debug);                                                                     
                                })
                                .RegisterPacketHandlerModule<PingPacketHandlerModule>()
                                .RegisterPacketHandlerModule<AudioPacketHandlerModule>()
                                .UseZeroFormatter()
                                .SetPacketBufferSize(2000000)
                                .Build();
                this.NetworkServer.Start();

                this.NetworkServer.ServerInformationUpdated += (sender, eventArgs) =>
                {
                    var dateTime = DateTime.UtcNow;

                    Console.WriteLine(
                        $"{dateTime} {eventArgs.ProcessedTcpPackets} TCP Packets Processed");
                    Console.WriteLine(
                        $"{dateTime} {eventArgs.InvalidTcpPackets} Invalid or Lost TCP Packets");
                    Console.WriteLine(
                        $"{dateTime} {eventArgs.ProcessedUdpPackets} UDP Packets Processed");
                    Console.WriteLine(
                        $"{dateTime} {eventArgs.InvalidUdpPackets} Invalid or Lost UDP Packets");
                    Console.WriteLine(
                        $"{dateTime} {eventArgs.TcpConnections} TCP connections active");
                };
                this.NetworkServer.ClientConnected += (sender, eventArgs) =>
                {
                    Console.WriteLine(
                        $"Client Connected - {eventArgs.Connection.Socket.RemoteEndPoint}");
                };
                this.NetworkServer.ClientDisconnected += (sender, eventArgs) =>
                {
                    Console.WriteLine(
                        $"Client Disconnected - {eventArgs.Connection.Socket.RemoteEndPoint}");
                };
                int idx = 0;
                Task.Factory.StartNew(() =>
                {
                    while (true && idx < 3)
                    {
                        var cfg = new ClientConfigurationPacket()
                        {
                            AudioSniffConfig = new AudioSniffConfigurationPacket() { CanRecive = true }
                        };
                        this.NetworkServer.SendToAllTCP<ClientConfigurationPacket>(cfg);


                        //this.NetworkServer.Broadcast(new PingPacket
                        //{
                        //    Time = DateTime.UtcNow
                        //});

                        Thread.Sleep(10000);
                        idx++;
                    }
                });



                run = true;
                while (run)
                {
                    Thread.Sleep(500);
                }
            }
            catch
            {
                
            }
        }

        public void Stop()
        {
            
        }
    }
}
