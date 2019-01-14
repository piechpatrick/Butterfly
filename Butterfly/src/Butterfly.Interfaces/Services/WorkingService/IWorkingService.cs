using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Services.WorkingService
{
    public interface IWorkingService
    {
        void Start();
        void Stop();
        bool IsRunning { get; }
    }
}
