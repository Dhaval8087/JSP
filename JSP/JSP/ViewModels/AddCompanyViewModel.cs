using DAL.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JSP.Models;
using JSP.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSP.ViewModels
{
    public class AddCompanyViewModel : ViewModelBase
    {
        private CompanyRepository companyRepo;
        public AddCompanyViewModel()
        {
            companyRepo = new CompanyRepository();
        }
        #region Properties
        private Company _CompanyDetails;

        public Company CompanyDetails
        {
            get { return _CompanyDetails ?? (_CompanyDetails = new Company()); }
            set { _CompanyDetails = value; RaisePropertyChanged(); }
        }

        #endregion
        #region Command
        private RelayCommand _addNewCompany;

        public RelayCommand AddNewCompany
        {
            get
            {
                return _addNewCompany ?? (_addNewCompany = new RelayCommand(() =>
                {
                    CheckValidation();
                    if (CompanyDetails.IsValid)
                    {
                        DAL.EDMX.Company_Details company = new DAL.EDMX.Company_Details
                        {
                            Address1 = CompanyDetails.Address1,
                            Address2 = CompanyDetails.Address2,
                            City = CompanyDetails.City,
                            Email = CompanyDetails.Email,
                            Mobile = CompanyDetails.Phone,
                            PAN = CompanyDetails.PAN,
                            Name = CompanyDetails.Name,
                            PinCode = CompanyDetails.Pin,
                            State = CompanyDetails.State,
                            BranchName= CompanyDetails.BranchName,
                            BankName= CompanyDetails.BankName,
                            AccountNumber= CompanyDetails.AccNo,
                            IFSCCode= CompanyDetails.IFSC
                        };
                        App.ContainerVM.IsBusy = true;
                        var result = companyRepo.Add(company);
                        if (!result.ResultSuccess)
                        {
                            HandlePopUp.ShowPopUp(result);
                        }
                        else
                        {
                            Messenger.Default.Send(this);
                        }
                        App.ContainerVM.IsBusy = false;
                    }
                }));
            }
            set { _addNewCompany = value; }
        }



        #endregion

        #region PrivateMethods
        private void CheckValidation()
        {
            if (string.IsNullOrEmpty(CompanyDetails.Name))
            {
                ShowError("Name");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.Address1))
            {
                ShowError("Street Address 1");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.City))
            {
                ShowError("City");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.State))
            {
                ShowError("State");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.Pin))
            {
                ShowError("PinCode");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.Phone))
            {
                ShowError("Phone");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.Email))
            {
                ShowError("Email");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.BankName))
            {
                ShowError("Bank Name");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.AccNo))
            {
                ShowError("Account Number");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.BranchName))
            {
                ShowError("Branch Name");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.IFSC))
            {
                ShowError("IFSC Code");
            }
            else if (string.IsNullOrEmpty(CompanyDetails.PAN))
            {
                ShowError("PAN CARD");
            }



        }
        private void ShowError(string FieldName)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show(FieldName + " is required !!");
            CompanyDetails.IsValid = false;
        }
        
        #endregion
    }
}
