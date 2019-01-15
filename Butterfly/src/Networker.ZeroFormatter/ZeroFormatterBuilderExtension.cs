using System;
using Microsoft.Extensions.DependencyInjection;
using Networker.Client.Abstractions;
using Networker.Common.Abstractions;
using Networker.Server.Abstractions;

namespace Networker.Formatter.ZeroFormatter
{
    public static class ZeroFormatterBuilderExtension
    {
        public static INetworkServerBuilder UseZeroFormatter(this INetworkServerBuilder serverBuilder)
        {
            var serviceCollection = serverBuilder.GetServiceCollection();
            serviceCollection.AddSingleton<IPacketSerialiser, ZeroFormatterPacketSerialiser>();

            return serverBuilder;
        }

        public static INetworkClientBuilder UseZeroFormatter(this INetworkClientBuilder clientBuilder)
        {
            var serviceCollection = clientBuilder.GetServiceCollection();
            serviceCollection.AddSingleton<IPacketSerialiser, ZeroFormatterPacketSerialiser>();
            return clientBuilder;
        }
    }
}