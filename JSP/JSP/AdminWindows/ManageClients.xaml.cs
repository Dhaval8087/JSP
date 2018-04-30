using GalaSoft.MvvmLight.Messaging;
using JSP.ViewModels;
using System.Windows;

namespace JSP.AdminWindows
{
    /// <summary>
    /// Interaction logic for ManageClients.xaml
    /// </summary>
    public partial class ManageClients : Window
    {
        public ManageClients()
        {
            InitializeComponent();
            Messenger.Default.Register<AddClientViewModel>(this, (send) =>
            {
                this.Close();
            });
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
