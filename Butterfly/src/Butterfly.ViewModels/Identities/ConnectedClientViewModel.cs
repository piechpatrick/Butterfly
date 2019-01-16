using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;

namespace Butterfly.MultiPlatform.ViewModels.Identities
{
    [ZeroFormattable]
    public class ConnectedClientViewModel : BindableBase
    {
        private string name;
        private string machineName;

        public ConnectedClientViewModel()
        {

        }

        [Index(0)]
        public virtual string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }

        [Index(1)]
        public virtual string MachineName
        {
            get { return this.machineName; }
            set { this.SetProperty(ref this.machineName, value); }
        }


    }
}
