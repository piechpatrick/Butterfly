using System;
using Microsoft.Extensions.DependencyInjection;
using Networker.Client.Abstractions;
using Networker.Common.Abstractions;
using Networker.Server.Abstractions;

namespace Networker.Formatter.ProtobufNet
{
    public static class ProtoBufNetBuilderExtension
    {
        public static INetworkServerBuilder UseProtobufNet(this INetworkServerBuilder serverBuilder)
        {
            var serviceCollection = serverBuilder.GetServiceCollection();
            serviceCollection.AddSingleton<IPacketSerialiser, ProtoBufNetSerialiser>();

            return serverBuilder;
        }

        public static INetworkClientBuilder UseProtobufNet(this INetworkClientBuilder clientBuilder)
        {
            var serviceCollection = clientBuilder.GetServiceCollection();
            serviceCollection.AddSingleton<IPacketSerialiser, ProtoBufNetSerialiser>();
            return clientBuilder;
        }
    }
}