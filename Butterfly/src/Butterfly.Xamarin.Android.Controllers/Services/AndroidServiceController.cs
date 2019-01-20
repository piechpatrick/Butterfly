using Butterfly.Multiplatform.Controllers.Services;
using Butterfly.MultiPlatform.Intefaces.Audio;
using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.MultiPlatform.Interfaces.Services;
using Android.Content;
using System.Collections.Generic;
using System.Linq;
using Android.App;

namespace Butterfly.Xamarin.Android.Controllers.Services
{
    public class AndroidServiceController : ServicesControllerBase
    {
        public AndroidServiceController(IAudioRecorderService recorderService)
        {
            this.services.Add(recorderService);
        }
        public override void Start(IService service)
        {
            Application.Context.StartService(new Intent(Application.Context, typeof(IService)));
        }
    }
}
