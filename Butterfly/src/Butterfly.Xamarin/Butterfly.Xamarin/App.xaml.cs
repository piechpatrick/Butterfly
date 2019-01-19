using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Butterfly.Xamarin.Views;
using System.Threading.Tasks;
using System.Threading;
using Android.Content;
using Butterfly.Xamarin.Core;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Butterfly.Xamarin
{
    public partial class App : Application
    {
        private static App instance;
        
        public static App Instance
        {
            get
            {
                lock(instance)
                {
                    return instance;
                }
            }
        }

        public ButterflyMobileClient Client { get; private set; }

        public Context Context { get; private set; }
        public App()
        {
            InitializeComponent();

            instance = this;


            MainPage = new MainPage();
        }

        public void StartService()
        {
            //var intent = new Android.Content.Intent(this.Context, typeof(RecorderService));
            //this.Context.StartService(intent);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    
    }
}
