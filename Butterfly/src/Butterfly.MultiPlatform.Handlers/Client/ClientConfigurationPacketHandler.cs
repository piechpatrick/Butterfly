using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.MultiPlatform.Packets.Audio;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Senders;
using Networker.Client.Abstractions;
using Networker.Common;
using Networker.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.MultiPlatform.Handlers.Client
{
    public class ClientConfigurationPacketHandler : PacketHandlerBase<ClientConfigurationPacket>
    {
        private readonly INetworkClient client;
        private readonly IRecorderService recorderService;
        private readonly IServiceController serviceController;

        public ClientConfigurationPacketHandler(IPacketSerialiser packetSerialiser, 
            INetworkClient client,
            IServiceController serviceController,
            IRecorderService recorderService)
            : base(packetSerialiser)
        {
            this.client = client;
            this.serviceController = serviceController;
            this.recorderService = recorderService;
        }

        public override async Task Process(ClientConfigurationPacket packet, ISender sender)
        {           
            if (packet != null)
            {
                if (!this.recorderService.IsRunning)
                {
                    if (packet.AudioSniffConfig.CanRecive)
                    {
                        

                    }
                        //this.recorderService.Start();                      
                }
                if(!packet.AudioSniffConfig.CanRecive)
                    this.recorderService.Stop();
            }

        }
    }
}
