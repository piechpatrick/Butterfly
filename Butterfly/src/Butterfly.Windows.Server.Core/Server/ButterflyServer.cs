using Butterfly.MultiPlatform.Packets.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Networker.Server.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.Server.Core.Server
{
    public class ButterflyServer : IButterflyServer
    {
        private bool run;
        private readonly IServiceCollection serviceCollection;
        private readonly INetworkServer networkServer;

        public ButterflyServer(IServiceCollection serviceCollection,
            INetworkServer networkServer)
        {
            this.serviceCollection = serviceCollection;
            this.networkServer = networkServer;
        }
        public void Start()
        {
            try
            {
                int threadsCount, k;
                ThreadPool.GetMaxThreads(out threadsCount, out k);

                
                this.networkServer.Start();

                this.networkServer.ServerInformationUpdated += (sender, eventArgs) =>
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
                this.networkServer.ClientConnected += (sender, eventArgs) =>
                {
                    Console.WriteLine(
                        $"Client Connected - {eventArgs.Connection.Socket.RemoteEndPoint}");
                };
                this.networkServer.ClientDisconnected += (sender, eventArgs) =>
                {
                    Console.WriteLine(
                        $"Client Disconnected - {eventArgs.Connection.Socket.RemoteEndPoint}");
                };
                var can = true;
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        
                        var cfg = new ClientConfigurationPacket()
                        {
                            AudioSniffConfig = new AudioSniffConfigurationPacket() { CanRecive = can }
                        };
                        this.networkServer.SendToAllTCP<ClientConfigurationPacket>(cfg);
                        can = !cfg.AudioSniffConfig.CanRecive;

                        //this.NetworkServer.Broadcast(new PingPacket
                        //{
                        //    Text = "test"
                        //});

                        Thread.Sleep(10000);
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
