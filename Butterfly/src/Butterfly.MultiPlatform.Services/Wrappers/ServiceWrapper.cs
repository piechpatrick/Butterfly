using Butterfly.MultiPlatform.Interfaces.Services.Workers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Services.Wrappers
{
    public class ServiceWrapper<TService> where TService : IWorkingService, new()
    {

        public ServiceWrapper()
        {

        }
    }
}
