using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Application
{
    public interface IApplication<TApplication> where TApplication : class
    {
        TApplication Application { get; }
    }
}
