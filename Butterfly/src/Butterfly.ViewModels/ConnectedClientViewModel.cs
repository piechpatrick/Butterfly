using Networker.Server.Abstractions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.ViewModels
{
    [ZeroFormattable]
    public class ConnectedClientViewModel : IConnectedClientViewModel
    {

        public ConnectedClientViewModel()
        {

        }

        [Index(0)]
        public virtual string Name { get; set; }

        [Index(1)]
        public virtual string MachineName { get; set; }
        [Index(3)]
        public virtual bool IsAdmin { get; set; }
    }
}
