using Butterfly.MultiPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter.Formatters;

namespace Butterfly.MultiPlatform.Modules.Unions
{
    public class DefaultDynamicUnionsModule
    {
        public DefaultDynamicUnionsModule()
        {
            Formatter.AppendDynamicUnionResolver((unionType, resolver) =>
            {
                //can be easily extended to reflection based scan if library consumer wants it
                if (unionType == typeof(IConnectedClientViewModel))
                {
                    resolver.RegisterUnionKeyType(typeof(byte));
                    resolver.RegisterSubType(key: (byte)1, subType: typeof(ConnectedClientViewModel));
                    resolver.RegisterFallbackType(typeof(Nullable));
                }
            });
        }

    }
}
