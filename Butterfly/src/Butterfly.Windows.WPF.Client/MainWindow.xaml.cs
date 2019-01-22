using Butterfly.Windows.WPF.Client.Abstractions.Snackbar;
using Butterfly.Windows.WPF.Client.Controls.Dialogs;
using Butterfly.Windows.WPF.Client.Core.Client;
using MaterialDesignThemes.Wpf;
using Networker.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Butterfly.Windows.WPF.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar Snackbar;
        public MainWindow(IButterflyWPFClient wpfClient, 
            ISnackbarController snackbarController, 
            INetworkClient networkClient)
        {
            InitializeComponent();

            Snackbar = this.MainSnackbar;

            networkClient.Connected += (sender, socket) =>
            {
                snackbarController.Enqueue($"Podłączono do serwera {socket.RemoteEndPoint}");
            };

            networkClient.Disconnected += (sender, socket) =>
            {
                snackbarController.Enqueue($"Rozłączono od serwera {socket.RemoteEndPoint}");
            };

            try
            {
                wpfClient.Start();
            }
            catch (Exception ex)
            {
                snackbarController.Enqueue(ex);
            }
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            var sampleMessageDialog = new SampleMessageDialog
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }
            };


            await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }

        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string stringValue)
            {
                try
                {
                    Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }
    }
}
