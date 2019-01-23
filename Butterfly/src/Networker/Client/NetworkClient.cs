using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Networker.Client.Abstractions;
using Networker.Common;
using Networker.Common.Abstractions;

namespace Networker.Client
{
    public class NetworkClient : INetworkClient
    {
        private readonly static object tcpLock = new object();


        private readonly ClientBuilderOptions options;
        private readonly IClientPacketProcessor packetProcessor;
        private readonly ILogger<NetworkClient> logger;
        private readonly IPacketSerialiser packetSerialiser;
        private bool isRunning = true;
        private Socket tcpSocket;
        private Socket tcpAudioSocket;
        private UdpClient udpClient;
        private IPEndPoint udpEndpoint;

        public NetworkClient(ClientBuilderOptions options,
            IPacketSerialiser packetSerialiser,
            IClientPacketProcessor packetProcessor,
            ILogger<NetworkClient> logger)
        {
            this.options = options;
            this.packetSerialiser = packetSerialiser;
            this.packetProcessor = packetProcessor;
            this.logger = logger;
        }

        public EventHandler<Socket> Connected { get; set; }
        public EventHandler<Socket> Disconnected { get; set; }

        public void Connect()
        {
            try
            {
                if (this.options.TcpPort > 0 && this.tcpSocket == null)
                {
                    this.tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.tcpSocket.Connect(this.options.Ip, this.options.TcpPort);
                    this.Connected?.Invoke(this, this.tcpSocket);

                    Task.Factory.StartNew(() =>
                                          {
                                              while (this.isRunning)
                                              {
                                                  if (this.tcpSocket.Poll(10, SelectMode.SelectWrite))
                                                  {
                                                      this.packetProcessor.Process(this.tcpSocket);
                                                  }

                                                  if (!this.tcpSocket.Connected)
                                                  {
                                                      this.Disconnected?.Invoke(this, this.tcpSocket);
                                                      break;
                                                  }
                                              }

                                              if (this.tcpSocket.Connected)
                                              {
                                                  this.tcpSocket.Disconnect(false);
                                                  this.tcpSocket.Close();
                                                  this.Disconnected?.Invoke(this, this.tcpSocket);
                                              }

                                              this.tcpSocket = null;
                                          });
                }

                if (this.options.UdpPort > 0 && this.udpClient == null)
                {
                    this.udpClient = new UdpClient(this.options.UdpPortLocal);
                    var address = IPAddress.Parse(this.options.Ip);
                    this.udpEndpoint = new IPEndPoint(address, this.options.UdpPort);

                    Task.Factory.StartNew(() =>
                                          {
                                              this.logger.LogInformation($"Connecting to UDP at {this.options.Ip}:{this.options.UdpPort}");

                                              while (this.isRunning)
                                              {
                                                  try
                                                  {
                                                      var data = this.udpClient.ReceiveAsync()
                                                                     .GetAwaiter()
                                                                     .GetResult();

                                                      this.packetProcessor.Process(data);
                                                      var res = this.ReadBySize(5000);
                                                  }
                                                  catch (Exception ex)
                                                  {
                                                      this.logger.Error(ex);
                                                  }
                                              }
                                              this.udpClient = null;
                                          });
                }
            }
            catch (Exception ex)
            {
                while (this.Connected == null)
                {
                    Thread.Sleep(2000);
                    this.Connect();
                }          
            }
        }

        private byte[] ReadBySize(int size = 4)
        {
            var readEvent = new AutoResetEvent(false);
            var buffer = new byte[size]; //Receive buffer
            var totalRecieved = 0;
            do
            {
                var recieveArgs = new SocketAsyncEventArgs()
                {
                    UserToken = readEvent
                };
                recieveArgs.SetBuffer(buffer, totalRecieved, size - totalRecieved);//Receive bytes from x to total - x, x is the number of bytes already recieved
                recieveArgs.Completed += TcpEventArgs_Completed;
                this.tcpSocket.ReceiveAsync(recieveArgs);
                readEvent.WaitOne();//Wait for recieve

                if (recieveArgs.BytesTransferred == 0)//If now bytes are recieved then there is an error
                {
                    continue;
                }
                totalRecieved += recieveArgs.BytesTransferred;

            } while (totalRecieved != size);//Check if all bytes has been received
            return buffer;
        }

        private void TcpEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            var are = (AutoResetEvent)e.UserToken;
            are.Set();
        }

        public int Ping()
        {
            throw new NotImplementedException();
            return 1235;
        }

        public void Send<T>(T packet)
        {
            try
            {
                if (this.tcpSocket == null)
                {
                    throw new Exception("TCP client has not been initialised");
                }

                var serialisedPacket = this.packetSerialiser.Serialise(packet);

                var result = this.tcpSocket.Send(serialisedPacket);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void SendUdp<T>(T packet)
        {
            if(this.udpClient == null)
            {
                throw new Exception("UDP client has not been initialised");
            }

            var serialisedPacket = this.packetSerialiser.Serialise(packet);

            this.udpClient.Send(serialisedPacket, serialisedPacket.Length, this.udpEndpoint);
        }

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}