using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Services.Workers
{
    public interface IWorkingService : IService
    {
        void Start();
        void Stop();
        bool IsRunning { get; }
    }
}
