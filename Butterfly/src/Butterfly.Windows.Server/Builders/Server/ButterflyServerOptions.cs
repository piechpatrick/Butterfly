using Butterfly.MultiPlatform.Interfaces.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Builders.Server
{
    public class ButterflyServerOptions : IBuilderOptions
    {
        public bool Active { get; set; }
    }
}
