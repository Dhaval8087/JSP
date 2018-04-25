using JSP.ViewModels;
using System.Windows.Controls;

namespace JSP.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
            this.DataContext = new LoginPageViewModel();
            username.Focus();
        }
    }
}
