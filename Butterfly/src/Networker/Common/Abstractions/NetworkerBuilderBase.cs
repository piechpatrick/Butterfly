using System;
using System.Collections.Generic;
using Butterfly.MultiPlatform.Interfaces.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Networker.Client.Abstractions;

namespace Networker.Common.Abstractions
{
    public abstract class NetworkerBuilderBase<TBuilder, TResult, TBuilderOptions> 
        : BuilderBase<TBuilder,TResult,TBuilderOptions>, INetworkerBuilder<TBuilder, TResult> 
        where TBuilder : class, INetworkerBuilder<TBuilder, TResult>
        where TBuilderOptions : class, INetworkerBuilderOptions
    {
        //Modules
        protected PacketHandlerModule module;
        protected List<IPacketHandlerModule> modules;

        public NetworkerBuilderBase()
            :base()
        {
            this.modules = new List<IPacketHandlerModule>();
            this.module = new PacketHandlerModule();
            this.modules.Add(this.module);
        }

        public override abstract TResult Build();

        public TBuilder RegisterPacketHandler<TPacket, TPacketHandler>()
            where TPacket : class
            where TPacketHandler : IPacketHandler
        {
            this.module.AddPacketHandler<TPacket, TPacketHandler>();
            return this as TBuilder;
        }

        public TBuilder RegisterPacketHandlerModule(IPacketHandlerModule packetHandlerModule)
        {
            this.modules.Add(packetHandlerModule);
            return this as TBuilder;
        }

        public TBuilder RegisterPacketHandlerModule<T>() where T : IPacketHandlerModule
        {
            this.modules.Add(Activator.CreateInstance<T>());
            return this as TBuilder;
        }

        public TBuilder SetLogLevel(LogLevel logLevel)
        {
            this.options.LogLevel = logLevel;
            return this as TBuilder;
        }

        public TBuilder SetPacketBufferSize(int size)
        {
            this.options.PacketSizeBuffer = size;
            return this as TBuilder;
        }

        public TBuilder UseTcp(int port)
        {
            this.options.TcpPort = port;
            return this as TBuilder;
        }

        public TBuilder UseUdp(int port)
        {
            this.options.UdpPort = port;
            return this as TBuilder;
        }

        protected void SetupSharedDependencies()
        {
            foreach (var packetHandlerModule in this.modules)
            {
                foreach (var packetHandler in packetHandlerModule.GetPacketHandlers())
                {
                    serviceCollection.AddSingleton(packetHandler.Value);
                }
            }

            if(this.loggingBuilder == null)
            {
                this.loggingBuilder = (loggingBuilder) =>
                                      {
                                          
                                      };
                
            }
            
            serviceCollection.AddSingleton<TBuilderOptions>(this.options);
            serviceCollection.AddSingleton<IPacketHandlers>(new PacketHandlers());
            serviceCollection.AddLogging(loggingBuilder => loggingBuilder.AddConsole());
        }

        public override IServiceProvider GetServiceProvider(IServiceProvider serviceProvider = null)
        {
            try
            {
                if (serviceProvider == null)
                    serviceProvider = this.serviceProviderFactory != null ? this.serviceProviderFactory.Invoke() : serviceCollection.BuildServiceProvider();

                PacketSerialiserProvider.PacketSerialiser = serviceProvider.GetService<IPacketSerialiser>();

                IPacketHandlers packetHandlers = serviceProvider.GetService<IPacketHandlers>();
                foreach (var packetHandlerModule in this.modules)
                {
                    foreach (var packetHandler in packetHandlerModule.GetPacketHandlers())
                    {
                        packetHandlers.Add(PacketSerialiserProvider.PacketSerialiser.CanReadName ? packetHandler.Key.Name : "Default",
                            (IPacketHandler)serviceProvider.GetService(packetHandler.Value));
                    }
                }

                if (!PacketSerialiserProvider.PacketSerialiser.CanReadName && packetHandlers.GetPacketHandlers().Count > 1)
                {
                    throw new Exception("A PacketSerialiser which cannot identify a packet can only support up to one packet type");
                }
            }
            catch(Exception ex)
            {

            }

            return serviceProvider;
        }

        public TBuilder RegiserUnionsModule<T>() where T : class
        {
            serviceCollection.AddSingleton<T>(Activator.CreateInstance<T>());
            return this as TBuilder;
        }
    }
}
