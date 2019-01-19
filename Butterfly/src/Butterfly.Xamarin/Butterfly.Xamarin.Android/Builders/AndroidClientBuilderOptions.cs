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
using Butterfly.Xamarin.Core.Builders;

namespace Butterfly.Xamarin.Droid.Builders
{
    public class AndroidClientBuilderOptions : IButterflyMobileClientBuilderOptions
    {
        public AndroidClientBuilderOptions()
        {

        }
        public bool Active { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}