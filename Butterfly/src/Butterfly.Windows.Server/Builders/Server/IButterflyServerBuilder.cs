using Butterfly.MultiPlatform.Interfaces.Builders;
using Butterfly.Server.Core.Server;
using Butterfly.Windows.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.Server.Builders.Server
{
    public interface IButterflyServerBuilder : IBuilder<IButterflyServerBuilder,IButterflyServer>
    {
        IButterflyService GetButterflyService();
    }
}
