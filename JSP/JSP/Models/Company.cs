using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSP.Models
{
    public class Company:ViewModelBase
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged(); }
        }

        private string _Address1;

        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; RaisePropertyChanged(); }
        }

        private string _Address2;

        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; RaisePropertyChanged(); }
        }

        private string _State;

        public string State
        {
            get { return _State; }
            set { _State = value; RaisePropertyChanged(); }
        }

        private string _City;

        public string City
        {
            get { return _City; }
            set { _City = value; RaisePropertyChanged(); }
        }
        private string _Pin;

        public string Pin
        {
            get { return _Pin; }
            set { _Pin = value; RaisePropertyChanged(); }
        }
        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; RaisePropertyChanged(); }
        }
        private string _PAN;

        public string PAN
        {
            get { return _PAN; }
            set { _PAN = value; RaisePropertyChanged(); }
        }

        private string _BankName;

        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; RaisePropertyChanged(); }
        }
        private string _AccNo;

        public string AccNo
        {
            get { return _AccNo; }
            set { _AccNo = value; RaisePropertyChanged(); }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; RaisePropertyChanged(); }
        }

        private string _BranchName;

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; RaisePropertyChanged(); }
        }
        private string _IFSC;

        public string IFSC
        {
            get { return _IFSC; }
            set { _IFSC = value; RaisePropertyChanged(); }
        }


        public bool IsValid { get; set; } = true;
    }
}
