
using System.Windows.Controls;


namespace Butterfly.Windows.WPF.Client.Controls.MainViews
{
    /// <summary>
    /// Interaction logic for ConnectedClientsView.xaml
    /// </summary>
    public partial class ConnectedClientsView : UserControl
    {
        public ConnectedClientsView()
        {
            InitializeComponent();
            var dataContext = this.DataContext as ConnectedClientsViewModel;
            dataContext.PropertyChanged += DataContext_PropertyChanged;
        }

        private void DataContext_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "LocationUrl")
            {
                BrowserMap.Source = new System.Uri((this.DataContext as ConnectedClientsViewModel).LocationUrl);
            }
        }
    }
}
