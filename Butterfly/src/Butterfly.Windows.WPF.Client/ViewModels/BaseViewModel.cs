using Butterfly.MultiPlatform.Packets.Video;
using Butterfly.Windows.Server.Handlers.WPFClient;
using Butterfly.Windows.WPF.Client.Core.Client;
using Butterfly.Windows.WPF.Client.Core.Events;
using Butterfly.Windows.WPF.Client.Core.HandlerWrappers.Video;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Butterfly.Windows.WPF.Client.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        protected readonly IButterflyWPFClient networkClient;
        protected readonly INv21PacketHandlerWrapper nv21PacketHandlerWrapper;
        protected readonly IEventAggregator eventAggregator;


        private ImageSource imageSource;

        public BaseViewModel()
        {

        }
        public BaseViewModel(IButterflyWPFClient networkClient,
            WPFNv21VideoPacketHandler nv21PacketHandler,
            INv21PacketHandlerWrapper nv21PacketHandlerWrapper,
            IEventAggregator eventAggregator)
        {
            this.networkClient = networkClient;
            this.networkClient.Start();

            nv21PacketHandlerWrapper.Attach(nv21PacketHandler);
            this.nv21PacketHandlerWrapper = nv21PacketHandlerWrapper;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<VideoFrameEvent>().Subscribe(this.OnFrameGotten, ThreadOption.UIThread);
        }

        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { this.SetProperty(ref this.imageSource, value); }
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
