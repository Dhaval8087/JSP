using GalaSoft.MvvmLight.Messaging;
using JSP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JSP.AdminWindows
{
    /// <summary>
    /// Interaction logic for ManageCompany.xaml
    /// </summary>
    public partial class ManageCompany : Window
    {
        public ManageCompany()
        {
            InitializeComponent();
            Messenger.Default.Register<AddCompanyViewModel>(this, (send) =>
            {
                Close();
            });
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
