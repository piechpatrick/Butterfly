using Butterfly.Windows.WPF.Client.Builders;
using Butterfly.Windows.WPF.Client.Core.Client;
using Networker.Client;
using Networker.Client.Abstractions;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace Butterfly.Windows.WPF.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var builder = new ButterflyWPFClientBuilder(Container.GetContainer());
            var client = builder.Build();
            return Container.Resolve<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            

        }
    }
}
