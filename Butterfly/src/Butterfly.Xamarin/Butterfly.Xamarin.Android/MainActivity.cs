﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using Xamarin.Essentials;
using Butterfly.Xamarin.Core.Builders;
using Butterfly.Xamarin.Droid.Builders;
using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.Xamarin.Android.Services.IO.Audio;
using Butterfly.Xamarin.Android.Controllers.Services;
using Android.Content;
using Networker.Client;
using Butterfly.MultiPlatform.Modules.HandlersModules;
using Networker.Formatter.ZeroFormatter;

namespace Butterfly.Xamarin.Droid
{
    [Activity(Label = "Butterfly.Xamarin", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            

            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState); // add this line to your code
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            var client = new AndroidClientBuilder().SetAudioRecorderService<AudioRecorderService>()
                            .SetServiceController<AndroidServiceController>()
                            .BuildNetworkClient()
                            .Build();          

            var app = new App();
            LoadApplication(app);
            


            Toast.MakeText(this, "BeforeCreate", ToastLength.Long).Show();
            //Application.Context.StartService(new Intent(this, typeof(RecorderService)));         

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.RecordAudio) == (int)Permission.Granted)
            {
                // We have permission, go ahead and use the camera.
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.RecordAudio }, 1);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) == (int)Permission.Granted)
            {
                // We have permission, go ahead and use the camera.
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessCoarseLocation }, 1);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == (int)Permission.Granted)
            {
                // We have permission, go ahead and use the camera.
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, 1);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReceiveBootCompleted) == (int)Permission.Granted)
            {
                // We have permission, go ahead and use the camera.
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, 1);
            }

            client.Start();


        }
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}