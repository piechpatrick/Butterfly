using Butterfly.MultiPlatform.Packets.Configuration;
using Butterfly.MultiPlatform.Packets.Video;
using Butterfly.MultiPlatform.ViewModels;
using Butterfly.Windows.Server.Handlers.WPFClient;
using Butterfly.Windows.WPF.Client.Abstractions.Snackbar;
using Butterfly.Windows.WPF.Client.Common.Events;
using Butterfly.Windows.WPF.Client.Core.Client;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Butterfly.Windows.WPF.Client.ViewModels
{
    public class BaseViewModel : BindableBase
    {

        protected readonly IButterflyWPFClient networkClient;
        protected readonly IEventAggregator eventAggregator;
        protected readonly IRegionManager regionManager;
        protected readonly ISnackbarController snackbarController;

        private ObservableCollection<ConnectedClientViewModel> connectedClientViewModels;


        private ImageSource imageSource;


        

        public BaseViewModel()
        {

        }
        public BaseViewModel(IButterflyWPFClient networkClient,
            IEventAggregator eventAggregator,
            IRegionManager regionManager,
            ISnackbarController snackbarController)
        {
            this.networkClient = networkClient;
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.snackbarController = snackbarController;
            this.eventAggregator.GetEvent<VideoFrameEvent>().Subscribe(this.OnFrameGotten, ThreadOption.UIThread);
            this.eventAggregator.GetEvent<ConnectedClientsPacketEvent>().Subscribe(this.OnClientsUpdateGot, ThreadOption.UIThread);
            this.ConnectedClientViewModels = new ObservableCollection<ConnectedClientViewModel>();
        }

        public ObservableCollection<ConnectedClientViewModel> ConnectedClientViewModels
        {
            get { return this.connectedClientViewModels; }
            set { this.SetProperty(ref this.connectedClientViewModels, value); }
        }

        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { this.SetProperty(ref this.imageSource, value); }
        }

        private void OnClientsUpdateGot(ConnectedClientsPacket e)
        {
            lock(this.ConnectedClientViewModels)
            {

                foreach (var item in this.ConnectedClientViewModels.Where(cc => String.IsNullOrEmpty(cc.Name)).ToList())
                {
                    this.ConnectedClientViewModels.Remove(item);
                }
                foreach (var cc in e.ConnectedClients)
                {
                    if (this.ConnectedClientViewModels
                        .Any(c => cc.ConnectedClientViewModel.Name == c.Name || String.IsNullOrEmpty(c.Name)))
                    {
                        var forUpdate = this.ConnectedClientViewModels
                            .Where(ccc => cc.ConnectedClientViewModel.Name == ccc.Name);
                        if (forUpdate.Count() > 0)
                        {
                            foreach (var u1 in forUpdate)
                            {
                                u1.Name = cc.ConnectedClientViewModel.Name;
                                u1.Name = cc.ConnectedClientViewModel.Machine;
                                u1.Latitude = cc.ConnectedClientViewModel.Latitude;
                                u1.Longitude = cc.ConnectedClientViewModel.Longitude;

                            }
                        }
                    }
                    else
                        this.ConnectedClientViewModels.Add(cc.ConnectedClientViewModel);
                }
            }
        }

        private static object lock__ = new object();
        List<Nv21FormatVideoPacket> buffor = new List<Nv21FormatVideoPacket>();
        private void OnFrameGotten(Nv21FormatVideoPacket frame)
        {
            lock (lock__)
            {
                if (frame.Data.Length == 65000)
                {
                    buffor.Add(frame);
                    return;
                }
                buffor.Add(frame);

                if (buffor.Count > 1)
                {
                    using (var ms = new MemoryStream(buffor.SelectMany(b => b.Data).ToArray()))
                    {
                        try
                        {
                            // var image = Image.FromStream(ms);
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.StreamSource = ms;
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.EndInit();
                            bitmap.Freeze();
                            ImageSource = bitmap;
                            //Thread.Sleep(33);

                            //var image = Image.FromStream(ms);
                            //image.Save("test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                        }
                        catch { }
                    }
                }

                buffor.Clear();
            }
        }

    }
}
