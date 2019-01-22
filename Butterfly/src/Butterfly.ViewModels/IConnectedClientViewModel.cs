using Networker.Server.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.ViewModels
{
    public interface IConnectedClientViewModel
    {
        string Name { get; }
        bool IsAdmin { get; set; }
    }
}
