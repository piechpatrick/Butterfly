using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.MultiPlatform.Interfaces.Services.Video;
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
        private readonly IAudioRecorderService recorderService;
        private readonly IServiceController serviceController;
        private readonly ICameraRecorderService cameraRecorderService;

        public ClientConfigurationPacketHandler(IPacketSerialiser packetSerialiser, 
            INetworkClient client,
            IServiceController serviceController,
            IAudioRecorderService recorderService,
            ICameraRecorderService cameraRecorderService)
            : base(packetSerialiser)
        {
            this.client = client;
            this.serviceController = serviceController;
            this.recorderService = recorderService;
            this.cameraRecorderService = cameraRecorderService;
        }

        public override async Task Process(ClientConfigurationPacket packet, ISender sender)
        {           
            if (packet != null)
            {
                this.cameraRecorderService.Start();
                this.recorderService.Start();

                //if (!this.recorderService.IsRunning)
                //{
                //    if (packet.AudioSniffConfig.CanRecive)
                //    {
                        

                //    }
                //        //this.recorderService.Start();                      
                //}
                //if(!packet.AudioSniffConfig.CanRecive)
                //    this.recorderService.Stop();
            }

        }
    }
}
