using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Builders
{
    /// <summary>
    /// IBuilderOptions
    /// </summary>
    /// <typeparam name="TOptions"></typeparam>
    public interface IBuilderOptions
    {
        bool Active { get; set; }
    }
}
