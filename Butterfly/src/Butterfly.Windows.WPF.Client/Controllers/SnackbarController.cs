using Butterfly.Windows.WPF.Client.Abstractions.Snackbar;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Butterfly.Windows.WPF.Client.Controllers
{
    public class SnackbarController : ISnackbarController
    {
        public SnackbarController()
        {
            
        }

        public void Enqueue(object @object)
        {
            //main thread synchro -.-"
            try
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    MainWindow.Snackbar.MessageQueue.Enqueue(@object);
                }));
            }
            catch { }
        }
    }
}
