﻿using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;
using Butterfly.MultiPlatform.Interfaces.Builders;

namespace Networker.Common.Abstractions
{
    public interface INetworkerBuilder<TBuilder, TResult> : IBuilder<TBuilder,TResult>
    {
        //Service Collection
        IServiceCollection GetServiceCollection();
        TBuilder SetServiceCollection(IServiceCollection serviceCollection, Func<IServiceProvider> serviceProviderFactory = null);

        //Packet Handler
        TBuilder RegisterPacketHandler<TPacket, TPacketHandler>()
            where TPacket : class where TPacketHandler : IPacketHandler;
        TBuilder RegisterPacketHandlerModule(IPacketHandlerModule packetHandlerModule);
        TBuilder RegisterPacketHandlerModule<T>()
            where T : IPacketHandlerModule;

        //Logging
        TBuilder SetLogLevel(LogLevel logLevel);

        TBuilder ConfigureLogging(Action<ILoggingBuilder> loggingBuilder);

        //Tcp
        TBuilder UseTcp(int port);

        //Udp
        TBuilder UseUdp(int port);

        //Info
        TBuilder SetPacketBufferSize(int size);

        IServiceProvider GetServiceProvider(IServiceProvider serviceProvider = null);
    }
}
