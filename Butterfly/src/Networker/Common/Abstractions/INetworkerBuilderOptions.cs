
using Butterfly.MultiPlatform.Interfaces.Builders;
using Microsoft.Extensions.Logging;

namespace Networker.Common.Abstractions
{
    public interface INetworkerBuilderOptions : IBuilderOptions
    {
        int TcpPort { get; set; }
        int UdpPort { get; set; }
        int PacketSizeBuffer { get; set; }
        LogLevel LogLevel { get; set; }
    }
}
