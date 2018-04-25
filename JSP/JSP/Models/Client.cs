using DAL.EDMX;
using GalaSoft.MvvmLight;
using System;

namespace JSP.Models
{
    public class Client : ViewModelBase
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

        private string _GST;

        public string GST
        {
            get { return _GST; }
            set { _GST = value; RaisePropertyChanged(); }
        }
        private DateTime _DOB = DateTime.Now;

        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; RaisePropertyChanged(); }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; RaisePropertyChanged(); }
        }

        private ReturnType _SelectedReturnType;

        public ReturnType SelectedReturnType
        {
            get { return _SelectedReturnType; }
            set
            {
                _SelectedReturnType = value;
                if (value != null && value.Id == 1)
                    GST = string.Empty;
                RaisePropertyChanged();
            }
        }


        public bool IsValid { get; set; } = true;
    }
}
