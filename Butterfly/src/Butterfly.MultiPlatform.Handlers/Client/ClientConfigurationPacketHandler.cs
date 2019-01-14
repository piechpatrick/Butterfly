using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.MultiPlatform.Packets.Audio;
using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Senders;
using Butterfly.MultiPlatform.Services.Audio;
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
        private readonly IClient client;
        private readonly IRecorderService recorderService;
        public ClientConfigurationPacketHandler(IPacketSerialiser packetSerialiser, IClient client)
            : base(packetSerialiser)
        {
            this.client = client;
            this.recorderService = new RecorderService(this.client);
        }

        public override async Task Process(ClientConfigurationPacket packet, ISender sender)
        {           
            if(packet != null)
            {

                var pcmSender = new GenericPacketSender<PCMPacket>(this.client);


                if (!this.recorderService.IsRunning)
                {
                    this.recorderService.Start();                  
                }
            }

        }
    }
}
