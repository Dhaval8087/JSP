using JSP.ViewModels;
using System.Windows.Controls;

namespace JSP.Views
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
            this.DataContext = new DashboardViewModel();
        }
    }
}
