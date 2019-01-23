using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.Windows.Server.Core.ConnectedClients;
using Microsoft.Extensions.DependencyInjection;
using Networker.Server.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Butterfly.Windows.Server.Handlers.Server;
using Butterfly.MultiPlatform.ViewModels;

namespace Butterfly.Server.Core.Server
{
    public class ButterflyServer : IButterflyServer
    {
        private bool run;
        private readonly INetworkServer networkServer;
        private readonly IConnectedClients connectedClients;
        private readonly ConnectedClientInfoHandler connectedClientInfoHandler;

        public ButterflyServer(
            INetworkServer networkServer,
            IConnectedClients connectedClients,
            ConnectedClientInfoHandler connectedClientInfoHandler)
        {
            this.networkServer = networkServer;
            this.connectedClients = connectedClients;
            this.connectedClientInfoHandler = connectedClientInfoHandler;
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
                    var viewModel = new MultiPlatform.ViewModels.ConnectedClientViewModelServerSide();
                    viewModel.Connection = eventArgs.Connection;
                    this.connectedClients.Add(viewModel);

                };
                this.networkServer.ClientDisconnected += (sender, eventArgs) =>
                {
                    Console.WriteLine(
                        $"Client Disconnected - {eventArgs.Connection.Socket.RemoteEndPoint}");
                    foreach (var client in this.connectedClients.GetAll())
                    {
                        
                    }
                };
                var can = true;
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        try
                        {

                            var cfg = new ClientConfigurationPacket()
                            {
                                AudioSniffConfig = new AudioSniffConfigurationPacket() { CanRecive = can }
                            };
                            this.networkServer.SendToAllTCP<ClientConfigurationPacket>(cfg);

                            //can = !cfg.AudioSniffConfig.CanRecive;

                            var admins = this.connectedClients.GetAll().Where(c => c.IsAdmin);
                            foreach (var item in admins)
                            {
                                var connectedd = this.connectedClients.GetAll().Cast<ConnectedClientViewModel>().ToList();
                                var packet = new ConnectedClientsPacket()
                                {
                                    ConnectedClients = new System.Collections.Generic.List<ConnectedClientInfoPacket>()
                                };
                                foreach (var connected in connectedd)
                                    packet.ConnectedClients.Add(new ConnectedClientInfoPacket() { ConnectedClientViewModel = connected });

                                networkServer.Send<ConnectedClientsPacket>(packet, item.Connection);
                            }

                            Thread.Sleep(10000);
                        }
                        catch { continue; }
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
