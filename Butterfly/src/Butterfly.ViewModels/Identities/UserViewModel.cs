using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.ViewModels.Identities
{
    public class UserViewModel : BindableBase
    {
        private string name;
        private string password;

        public string Name
        {
            get { return this.password; }
            set { this.SetProperty(ref this.password, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { this.SetProperty(ref this.password, value); }
        }
    }
}
