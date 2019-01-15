using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Builders
{
    /// <summary>
    /// Build
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IBuilder<TBuilder, TResult>
    {
        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        TResult Build();
    }
}
