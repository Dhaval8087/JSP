using DAL.EDMX;
using DAL.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JSP.Invoices;
using JSP.Models;
using JSP.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JSP.ViewModels
{
    public class GenerateInvoiceViewModel : ViewModelBase
    {
        private AccessYearRepository accessRepo;
        private ClientInvoiceRespository invoiceRepo;
        public GenerateInvoiceViewModel(DAL.EDMX.Client client)
        {
            accessRepo = new AccessYearRepository();
            invoiceRepo = new ClientInvoiceRespository();
            Client = client;
            NoRecordFound = Visibility.Collapsed;
            LoadAccessYear();
            Messenger.Default.Register<InvoiceInformationViewModel>(this, (send) =>
            {
                LoadInvoices();
            });
        }
        #region Properties
        private Visibility _NoRecordFound;

        public Visibility NoRecordFound
        {
            get { return _NoRecordFound; }
            set { _NoRecordFound = value; RaisePropertyChanged(); }
        }


        public DAL.EDMX.Client Client { get; set; }
        private ObservableCollection<AccessYear> _AYCollections;

        public ObservableCollection<AccessYear> AYCollections
        {
            get { return _AYCollections ?? (_AYCollections = new ObservableCollection<AccessYear>()); }
            set { _AYCollections = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<Invoice> _Invoices;

        public ObservableCollection<Invoice> Invoices
        {
            get { return _Invoices; }
            set { _Invoices = value; RaisePropertyChanged(); }
        }

        public AccessYear SelectedYear { get; set; }
        #endregion



        #region Commands
        private RelayCommand<object> _SelectedAYChangedCommand;

        public RelayCommand<object> SelectedAYChangedCommand
        {
            get
            {
                return _SelectedAYChangedCommand ?? (_SelectedAYChangedCommand = new RelayCommand<object>((obj) =>
            {
                SelectedYear = obj as AccessYear;
                LoadInvoices();
                NoRecordFound = Visibility.Visible;
            }));
            }
            set { _SelectedAYChangedCommand = value; }
        }

        private RelayCommand _GenerateInvoiceCommand;

        public RelayCommand GenerateInvoiceCommand
        {
            get
            {
                return _GenerateInvoiceCommand ?? (_GenerateInvoiceCommand = new RelayCommand(() =>
            {
                if (SelectedYear != null)
                {
                    InvoiceInformation information = new InvoiceInformation();
                    information.DataContext = new InvoiceInformationViewModel(Client, SelectedYear);
                    information.Show();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Please Select the Access Year");
                }

            }));
            }
            set { _GenerateInvoiceCommand = value; }
        }
        private RelayCommand<object> _SelectedInvoiceCommand;

        public RelayCommand<object> SelectedInvoiceCommand
        {
            get
            {
                return _SelectedInvoiceCommand ?? (_SelectedInvoiceCommand = new RelayCommand<object>((invoice) =>
            {
                var inv = invoice as Invoice;
                System.Diagnostics.Process.Start(inv.Path);

            }));
            }
            set { _SelectedInvoiceCommand = value; }
        }


        #endregion

        #region PrivateMethods
        private void LoadAccessYear()
        {
            AYCollections = accessRepo.GetAll().ToObservableCollection();
        }
        private void LoadInvoices()
        {
            Invoices = new ObservableCollection<Invoice>();
            var invoices = invoiceRepo.GetInvoices(SelectedYear.AY);
            invoices.ForEach(item =>
            {
                Invoices.Add(new Invoice
                {
                    Id = item.Id,
                    InvoiceNumber = item.InvoiceNumber,
                    Name = item.Client_Details.Client.Name,
                    Pan = item.Client_Details.Client.PAN,
                    Path = item.Path ?? string.Empty
                });
            });
        }
        #endregion
    }
}
