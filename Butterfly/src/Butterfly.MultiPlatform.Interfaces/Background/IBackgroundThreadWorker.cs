using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Background
{
    public interface IBackgroundThreadWorker
    {
        /// <summary>
        /// Start
        /// </summary>
        void Start();
        /// <summary>
        /// Stop
        /// </summary>
        void Stop();
    }
}
