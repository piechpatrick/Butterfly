using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Butterfly.MultiPlatform.Services.Audio;

namespace Butterfly.Xamarin.Droid
{
    [BroadcastReceiver(Name = "com.companyname.Butterfly.Xamarin.BroadcastReceiverTest")]
    public class BroadcastReceiverTest : BroadcastReceiver
    {
        public BroadcastReceiverTest()
            :base()
        {
            
        }

        public override void OnReceive(Context context, Intent intent)
        {
            context.StartService(new Intent(context, typeof(RecorderService)));

        }
    }
}