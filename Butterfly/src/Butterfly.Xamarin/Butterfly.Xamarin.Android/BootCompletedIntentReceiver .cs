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
using Butterfly.Xamarin.Core;

namespace Butterfly.Xamarin.Droid
{
    [BroadcastReceiver(Name = "com.companyname.Butterfly.Xamarin.BootCompletedIntentReceiver")]
    public class BootCompletedIntentReceiver : BroadcastReceiver
    {
        public BootCompletedIntentReceiver()
        {

        }
        public override void OnReceive(Context context, Intent intent)
        {

           // var client = new ButterflyMobileClient();
        }
    }
}