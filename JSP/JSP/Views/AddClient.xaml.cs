using JSP.ViewModels;
using System.Windows.Controls;

namespace JSP.Views
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : UserControl
    {
        public AddClient()
        {
            InitializeComponent();
            this.DataContext = new AddClientViewModel();
        }
    }
}
