using Butterfly.MultiPlatform.Interfaces.Controllers;
using Butterfly.Windows.WPF.Client.Common.Events;
using Butterfly.Windows.WPF.Client.Core.Client;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.Core.Controllers
{
    public class EventsController : IEventsController
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IButterflyWPFClient butterflyWPFClient;
        public EventsController(IEventAggregator eventAggregator, 
            IButterflyWPFClient butterflyClient)
        {
            this.eventAggregator = eventAggregator;
            this.butterflyWPFClient = butterflyClient;
        }

        public void AttachEvents()
        {
            //this.eventAggregator.GetEvent<VideoFrameEvent>().Subscribe(this.OnFrameGotten, ThreadOption.UIThread);
            //this.eventAggregator.GetEvent<ConnectedClientsPacketEvent>().Subscribe(this.OnClientsUpdateGot, ThreadOption.UIThread);
        }

        public void DetachEvents()
        {
            
        }
    }
}
