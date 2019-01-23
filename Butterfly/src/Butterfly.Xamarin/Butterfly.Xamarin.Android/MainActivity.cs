using System;

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
using Butterfly.Xamarin.Android.Services.IO.Video;
using Plugin.Media;
using Plugin.CurrentActivity;
using Butterfly.MultiPlatform.Interfaces.Application;
using Butterfly.Xamarin.Android.Services.Updaters;
using Butterfly.Xamarin.Permissions;
using Android.Gms.Common.Apis;
using static Android.Gms.Common.Apis.GoogleApiClient;
using Android.Gms.Common;
using Android.Gms.Location;

namespace Butterfly.Xamarin.Droid
{
    [Activity(Label = "Butterfly.Xamarin", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IApplication<Application>
    {
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            

            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState); // add this line to your code
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            var client = new AndroidClientBuilder()
                            .Build();

            client.SetContext(this.Application.ApplicationContext);
            
            var app = new App();
            LoadApplication(app);

            await CrossMedia.Current.Initialize();
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            //Application.Context.StartService(new Intent(this, typeof(RecorderService)));         

            await CrossPermissionChecker.CheckAllPermissions();

           client.Start();

        }     

    }    
}