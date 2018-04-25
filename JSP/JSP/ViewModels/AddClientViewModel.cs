using DAL.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        #region Command
        private RelayCommand _addNewClient;

        public RelayCommand AddNewClient
        {
            get
            {
                return _addNewClient ?? (_addNewClient = new RelayCommand(() =>
            {
                CheckValidation();
                if (CustomerDetails.IsValid)
                {

                }
            }));
            }
            set { _addNewClient = value; }
        }


        #endregion

        #region PrivateMethods
        private void CheckValidation()
        {
            if (string.IsNullOrEmpty(CustomerDetails.Name))
            {
                ShowError("Name");
            }
            else if (string.IsNullOrEmpty(CustomerDetails.Address1))
            {
                ShowError("Street Address 1");
            }
            else if (string.IsNullOrEmpty(CustomerDetails.City))
            {
                ShowError("City");
            }
            else if (string.IsNullOrEmpty(CustomerDetails.State))
            {
                ShowError("State");
            }
            else if (string.IsNullOrEmpty(CustomerDetails.Pin))
            {
                ShowError("PinCode");
            }
            else if (string.IsNullOrEmpty(CustomerDetails.Phone))
            {
                ShowError("Phone");
            }
            else if (string.IsNullOrEmpty(CustomerDetails.Email))
            {
                ShowError("Email");
            }
            else if(CustomerDetails.SelectedReturnType==null)
            {
                ShowError("Return type");
            }
            else if(CustomerDetails.SelectedReturnType.Id==2 && string.IsNullOrEmpty(CustomerDetails.GST))
            {
                ShowError("GST");
            }
            else if(string.IsNullOrEmpty(CustomerDetails.PAN))
            {
                ShowError("PAN CARD");
            }
           


        }
        private void ShowError(string FieldName)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show(FieldName + " is required !!");
            CustomerDetails.IsValid = false;
        }
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
