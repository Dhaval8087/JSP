using DAL.EDMX;
using DAL.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JSP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSP.ViewModels
{
    public class InvoiceInformationViewModel : ViewModelBase
    {
        private CompanyRepository companyRepo;
        private ClientRepository clientRepo;
        public InvoiceInformationViewModel(DAL.EDMX.Client client, AccessYear ay)
        {
            Client = client;
            AY = ay;
            companyRepo = new CompanyRepository();
            clientRepo = new ClientRepository();
            LoadCompayDetails();
        }

        #region Properties
        public Client Client { get; set; }
        public AccessYear AY { get; set; }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; RaisePropertyChanged(); }
        }
        private string _Description1;

        public string Description1
        {
            get { return _Description1; }
            set { _Description1 = value; RaisePropertyChanged(); }
        }
        private string _Description2;

        public string Description2
        {
            get { return _Description2; }
            set { _Description2 = value; RaisePropertyChanged(); }
        }
        private decimal _Rate;

        public decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; RaisePropertyChanged(); }
        }
        private DateTime _InvoiceDate = DateTime.Today;

        public DateTime InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; RaisePropertyChanged(); }
        }
        private Company_Details _CompanyDetails;

        public Company_Details CompanyDetails
        {
            get { return _CompanyDetails; }
            set { _CompanyDetails = value; }
        }

        #endregion

        #region Commands
        private RelayCommand _GeneratePDFCommand;

        public RelayCommand GeneratePDFCommand
        {
            get
            {
                return _GeneratePDFCommand ?? (_GeneratePDFCommand = new RelayCommand(() =>
            {
                Client_Details details = new Client_Details
                {
                    AY = AY.AY,
                    ClientId = Client.Id
                };
                CreatePdf create = new CreatePdf();
                var path=create.CreatePdf12(this);
                var response = clientRepo.AddClientDetails(details, path);
                if(response.ResultSuccess)
                {
                    Messenger.Default.Send(this);
                }
                else
                {
                    HandlePopUp.ShowPopUp(response);
                }
               

            }));
            }
            set { _GeneratePDFCommand = value; }
        }



        #endregion

        #region Private Methods
        private async void LoadCompayDetails()
        {
            App.ContainerVM.IsBusy = true;
            await Task.Run(() =>
            {
                CompanyDetails = companyRepo.Get().FirstOrDefault() ?? new Company_Details();
                App.ContainerVM.IsBusy = false;
            });
        }
        #endregion
    }


}
