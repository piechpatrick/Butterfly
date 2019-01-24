using Butterfly.Windows.WPF.Client.Abstractions.Snackbar;
using Butterfly.Windows.WPF.Client.Builders;
using Butterfly.Windows.WPF.Client.Controllers;
using Butterfly.Windows.WPF.Client.Core.Client;
using CommonServiceLocator;
using MaterialDesignThemes.Wpf;
using Networker.Client;
using Networker.Client.Abstractions;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace Butterfly.Windows.WPF.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var container = Container.GetContainer();
            var builder = new ButterflyWPFClientBuilder(container);

            var regionManager = container.Resolve<IRegionManager>();

            var client = builder.Build();
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocatorAdapter(this.Container.GetContainer()));
            containerRegistry.RegisterSingleton<ISnackbarController, SnackbarController>();
        }
    }
}
