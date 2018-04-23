using GalaSoft.MvvmLight;
using JSP.Views;
using System.Windows.Controls;

namespace JSP.ViewModels
{
    public  class JSPViewModelBase : ViewModelBase
    {
        public JSPViewModelBase()
        {
            Content.Content = new LoginPage();

        }
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



    }
}
