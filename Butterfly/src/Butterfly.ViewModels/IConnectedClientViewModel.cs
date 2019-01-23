using Networker.Server.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.ViewModels
{
    public interface IConnectedClientViewModel
    {
        string Name { get; set; }
        bool IsAdmin { get; set; }
        string Machine { get; set; }

        double Longitude { get; set; }

        double Latitude { get; set; }
    }
}
