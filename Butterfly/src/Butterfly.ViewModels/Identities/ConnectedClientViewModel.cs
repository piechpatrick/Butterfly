using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.ViewModels.Identities
{
    public class ConnectedClientViewModel : BindableBase
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }
    }
}
