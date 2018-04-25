using DAL.Impl;
using GalaSoft.MvvmLight;
using JSP.Models;
using JSP.Util;
using System.Collections.ObjectModel;

namespace JSP.ViewModels
{
    public class AddClientViewModel : ViewModelBase
    {
        private ReturnTypeRepository returnTypeRepo;
        public AddClientViewModel()
        {
            returnTypeRepo = new ReturnTypeRepository();
            App.ContainerVM.IsBusy = true;
            LoadReturnTypes();
        }
        #region Properties
        private Client _CustomerDetails;

        public Client CustomerDetails
        {
            get { return _CustomerDetails ?? (_CustomerDetails = new Client()); }
            set { _CustomerDetails = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DAL.EDMX.ReturnType> _ReturnTypes;

        public ObservableCollection<DAL.EDMX.ReturnType> ReturnTypes
        {
            get { return _ReturnTypes ?? (_ReturnTypes = new ObservableCollection<DAL.EDMX.ReturnType>()); }
            set { _ReturnTypes = value; RaisePropertyChanged(); }
        }


        #endregion

        #region PrivateMethods
        private void LoadReturnTypes()
        {
            try
            {
                ReturnTypes = returnTypeRepo.GetAll().ToObservableCollection();
            }
            catch (System.Exception ex)
            {
                Log4Net.WriteException(ex);
            }
            finally
            {
                App.ContainerVM.IsBusy = false;
            }
        }
        #endregion
    }
}
