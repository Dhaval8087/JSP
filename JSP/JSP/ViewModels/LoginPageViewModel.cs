using DAL.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JSP.Views;

namespace JSP.ViewModels
{
    internal class LoginPageViewModel : ViewModelBase
    {
        LoginRepository _repository;
        public LoginPageViewModel()
        {
            _repository = new LoginRepository();
        }

        #region Properties
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; RaisePropertyChanged(); }
        }



        #endregion

        #region Commands
        private RelayCommand<object> _LoginCommand;

        public RelayCommand<object> LoginCommand
        {
            get
            {
                return _LoginCommand ?? (_LoginCommand = new RelayCommand<object>((obj) =>
            {
                //App.ContainerVM.Content.Content = new AddClient();
                App.ContainerVM.Content.Content = new DashBoard();
                /* var password = (obj as PasswordBox)?.Password;
                 if (_repository.AutheticateUser(Username, password))
                 {
                     App.ContainerVM.Content.Content = new DashBoard();
                 }*/

            }));
            }
            set { _LoginCommand = value; }
        }


        #endregion
    }
}