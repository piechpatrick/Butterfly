using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.MultiPlatform.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Multiplatform.Controllers.Services
{
    public abstract class ServicesControllerBase : IServiceController
    {
        protected List<IService> services;
        public ServicesControllerBase()
        {
            this.services = new List<IService>();
        }

        public abstract void Start(IService service);
    }
}
