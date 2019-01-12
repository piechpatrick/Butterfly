using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Server.Core.Instances
{
    public interface IButterflyServer
    {
        void Start();
        void Stop();
    }
}
