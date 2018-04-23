using JSP.ViewModels;
using System.Windows;

namespace JSP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ContainerPage : Window
    {
        public ContainerPage()
        {
            InitializeComponent();
            this.DataContext = new JSPViewModelBase();
        }
    }
}
