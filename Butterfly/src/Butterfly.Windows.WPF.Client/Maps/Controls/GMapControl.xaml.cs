using System.Windows.Controls;


namespace Butterfly.Windows.WPF.Client.Maps.Controls
{
    /// <summary>
    /// Interaction logic for GMapControl.xaml
    /// </summary>
    public partial class GMapControl : UserControl
    {
        public GMapControl()
        {
            InitializeComponent();
            MapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            MapControl.SetPositionByKeywords("Warsaw");
            MapControl.DragButton = System.Windows.Input.MouseButton.Left;
            MapControl.MinZoom = 5;
            MapControl.MaxZoom = 10;
            MapControl.Position = new GMap.NET.PointLatLng() { Lat = 20.860602, Lng = 52.202011 };
            MapControl.Zoom = 10;
        }
    }
}
