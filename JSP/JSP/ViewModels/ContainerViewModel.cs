using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JSP.AdminWindows;
using JSP.Views;
using System.Windows;
using System.Windows.Controls;

namespace JSP.ViewModels
{
    public class ContainerViewModel : ViewModelBase
    {
        public ContainerViewModel()
        {
            Content.Content = new LoginPage();
        }
        #region Properties
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; RaisePropertyChanged(); }
        }

        private ContentControl _Content;

        public ContentControl Content
        {
            get { return _Content ?? (_Content = new ContentControl()); }
            set { _Content = value; RaisePropertyChanged(); }
        }
        private Visibility _AYMenuVisbility = Visibility.Collapsed;

        public Visibility AYMenuVisbility
        {
            get { return _AYMenuVisbility; }
            set { _AYMenuVisbility = value; RaisePropertyChanged(); }
        }


        #endregion
        #region Commands
        private RelayCommand _ExitCommand;

        public RelayCommand ExitCommand
        {
            get
            {
                return _ExitCommand ?? (_ExitCommand = new RelayCommand(() =>
            {
                App.Current.Shutdown();
            }));
            }
            set { _ExitCommand = value; }
        }

        private RelayCommand _AYCommand;

        public RelayCommand AYCommand
        {
            get
            {
                return _AYCommand ?? (_AYCommand = new RelayCommand(() =>
            {
                ManageAY ay = new ManageAY();
                ay.DataContext = new ManageAYViewModel();
                ay.Show();
            }));
            }
            set { _AYCommand = value; }
        }

        #endregion


    }
}
