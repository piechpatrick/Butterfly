using Butterfly.MultiPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Xamarin.Core
{
    public interface IButterflyMobileClient
    {
        IConnectedClientViewModel ClientViewModel { get; }
        void Start();

        void PublishSelfInfo();

        void SetContext(object context);
        object GetContext();
    }
}
