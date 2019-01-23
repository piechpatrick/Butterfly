using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Controllers
{
    public interface IEventsController
    {
        void AttachEvents();
        void DetachEvents();
    }
}
