using Butterfly.MultiPlatform.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Controllers
{
    public interface IServiceController
    {
        void Start(IService service);
    }
}
