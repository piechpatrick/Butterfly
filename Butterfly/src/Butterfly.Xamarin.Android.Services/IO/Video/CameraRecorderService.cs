using Butterfly.MultiPlatform.Interfaces.Services.Video;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Android.Hardware;

using Graph = Android.Graphics;
using Butterfly.MultiPlatform.StaticTools.Unsafe.Bitmap;
using Butterfly.MultiPlatform.Senders.UDP;
using Networker.Client.Abstractions;
using System.Linq;
using Java.IO;
using System.IO;

namespace Butterfly.Xamarin.Android.Services.IO.Video
{
    public class CameraRecorderService : ICameraRecorderService
    {
        public bool IsRunning => throw new NotImplementedException();
        int idx = 0;
        private GenericUDPPacketSender<MultiPlatform.Packets.Video.Nv21FormatVideoPacket> nv21Sender;

        Camera _camera;
        Graph.SurfaceTexture _textureView = new Graph.SurfaceTexture(10);
        public CameraRecorderService(INetworkClient networkClient)
        {
            nv21Sender = new GenericUDPPacketSender<MultiPlatform.Packets.Video.Nv21FormatVideoPacket>(networkClient);
        }

        public async void Start()
        {
            if (idx == 0)
            {
                idx++;

                _camera = Camera.Open(1);
                var camParams = _camera.GetParameters();
                var fps = camParams.SupportedPreviewFpsRange;
                camParams.SetPreviewSize(640, 480);
                camParams.SetPreviewFpsRange(fps[0][0], fps[0][1]);
                var supportedPictureFormats = camParams.SupportedPictureFormats;
                var previewFormat = camParams.PreviewFormat;
                var supportedpreviewFormat = camParams.SupportedPreviewFormats;
                foreach (var item in supportedpreviewFormat)
                {
                    Graph.ImageFormatType type = (Graph.ImageFormatType)item.IntValue();
                }
                _camera.SetParameters(camParams);
                _camera.SetPreviewTexture(_textureView);
                _camera.SetDisplayOrientation(90);
                _camera.SetPreviewCallback(new CameraPreviewCallback(this.nv21Sender));
                _camera.StartPreview();


                //if (CrossMedia.Current.IsTakePhotoSupported)
                //{
                //    await this.CheckPermissions();
                //    try
                //    {
                //        await CrossMedia.Current.Initialize();
                //        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                //        { DefaultCamera = CameraDevice.Front }
                //        );

                //    }
                //    catch (Exception e)
                //    {

                //    }
                //}
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        private class CameraPreviewCallback : Java.Lang.Object, Camera.IPreviewCallback
        {
            GenericUDPPacketSender<MultiPlatform.Packets.Video.Nv21FormatVideoPacket> sender;
            public CameraPreviewCallback(GenericUDPPacketSender<MultiPlatform.Packets.Video.Nv21FormatVideoPacket> genericUDPPacketSender)
            {
                this.sender = genericUDPPacketSender;
            }

            public void OnPreviewFrame(byte[] data, Camera camera)
            {
                using (var ms = new MemoryStream())
                {
                    Graph.YuvImage yuvImage = new Graph.YuvImage(data, Graph.ImageFormatType.Nv21, 640, 480, null);
                    yuvImage.CompressToJpeg(new Graph.Rect(0, 0, 640, 480), 100, ms);
                    var msArray = ms.ToArray();
                    var splittedArray = this.SplitToSublists(msArray.ToList());

                    foreach (var item in splittedArray)
                    {
                        this.sender.Send(new MultiPlatform.Packets.Video.Nv21FormatVideoPacket() { IsPart = true, Data = item.ToArray() });
                    }
                }


            }

            public List<List<byte>> SplitToSublists(List<byte> source)
            {
                return source
                         .Select((x, i) => new { Index = i, Value = x })
                         .GroupBy(x => x.Index / 65000)
                         .Select(x => x.Select(v => v.Value).ToList())
                         .ToList();
            }
        }

    }  
}
