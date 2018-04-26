using System.Windows;

namespace JSP.AdminWindows
{
    /// <summary>
    /// Interaction logic for ManageAY.xaml
    /// </summary>
    public partial class ManageAY : Window
    {
        public ManageAY()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
