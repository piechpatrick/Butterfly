using Butterfly.Maps.Entities;
using Butterfly.Server.Core;
using Butterfly.Server.Core.Instances;
using Butterfly.Services.Database.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Butterfly.Server.Shell
{
    internal class Bootstrapper
    {
        protected UnityContainer UnityContainer { get; private set; }
        public Bootstrapper()
        {
            this.UnityContainer = new UnityContainer();
        }

        public void Build()
        {
            this.UnityContainer.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
            this.UnityContainer.RegisterType<IUserMap, UserMap>(new ContainerControlledLifetimeManager());
            this.UnityContainer.RegisterType<IButterflyServer, ButterflyServer>(new ContainerControlledLifetimeManager());
        }

        public TItem Reslove<TItem>()
        {
            return this.UnityContainer.Resolve<TItem>();
        }
    }
}
