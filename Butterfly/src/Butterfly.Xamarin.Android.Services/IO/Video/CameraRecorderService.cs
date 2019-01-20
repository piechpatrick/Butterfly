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

namespace Butterfly.Xamarin.Android.Services.IO.Video
{
    public class CameraRecorderService : ICameraRecorderService
    {
        public bool IsRunning => throw new NotImplementedException();
        int idx = 0;

        Camera _camera;
        Graph.SurfaceTexture _textureView = new Graph.SurfaceTexture(10);

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
                _camera.SetPreviewCallback(new CameraPreviewCallback());
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

        private async Task<bool> CheckPermissions()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {

            }

            else
            {

            }
            return true;
        }

        private class CameraPreviewCallback : Java.Lang.Object, Camera.IPreviewCallback
        {
            public void OnPreviewFrame(byte[] data, Camera camera)
            {

            }
        }
    }
}
