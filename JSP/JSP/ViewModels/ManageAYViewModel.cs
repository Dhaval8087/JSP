using DAL.Dtos;
using DAL.EDMX;
using DAL.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JSP.Util;
using System.Collections.ObjectModel;
namespace JSP.ViewModels
{
    public class ManageAYViewModel : ViewModelBase
    {
        private AccessYearRepository accessRepo;

        public ManageAYViewModel()
        {
            accessRepo = new AccessYearRepository();
            LoadAccessYear();
        }
        #region Properties
        private ObservableCollection<AccessYear> _AYCollections;

        public ObservableCollection<AccessYear> AYCollections
        {
            get { return _AYCollections ?? (_AYCollections = new ObservableCollection<AccessYear>()); }
            set { _AYCollections = value; RaisePropertyChanged(); }
        }
        private bool _OpenDialog = false;

        public bool OpenDialog
        {
            get { return _OpenDialog; }
            set { _OpenDialog = value; RaisePropertyChanged(); }
        }
        private string _NewAY;

        public string NewAY
        {
            get { return _NewAY; }
            set { _NewAY = value; RaisePropertyChanged(); }
        }
        private AccessYear _SelectedAccessYear;

        public AccessYear SelectedAccessYear
        {
            get { return _SelectedAccessYear ?? (_SelectedAccessYear = new AccessYear()); }
            set { _SelectedAccessYear = value; }
        }

        public bool IsEdit { get; set; } = false;
        #endregion

        #region PrivateMethods
        private void LoadAccessYear()
        {
            AYCollections = accessRepo.GetAll().ToObservableCollection();
        }
        #endregion

        #region Commands
        private RelayCommand _AddAY;

        public RelayCommand AddAY
        {
            get
            {
                return _AddAY ?? (_AddAY = new RelayCommand(() =>
            {
                OpenDialog = true;

            }));
            }
            set { _AddAY = value; }
        }

        private RelayCommand<object> _ActionAYCommand;

        public RelayCommand<object> ActionAYCommand
        {
            get
            {
                return _ActionAYCommand ?? (_ActionAYCommand = new RelayCommand<object>((obj) =>
            {
                ResponseBase result = null;
                if (obj.Equals("0"))
                {
                    OpenDialog = false;
                    return;
                }
                if (obj.ToString() == "1" && !IsEdit)
                {
                    AccessYear accessyr = new AccessYear
                    {
                        AY = NewAY
                    };
                    result = accessRepo.Add(accessyr);
                }
                else if (obj.ToString() == "1" && IsEdit)
                {
                    var accessYear = new AccessYear
                    {
                        Id = SelectedAccessYear.Id,
                        AY = NewAY
                    };
                    result = accessRepo.Update(accessYear);
                }
                if (!result.ResultSuccess)
                    HandlePopUp.ShowPopUp(result);
                else
                    LoadAccessYear();

                OpenDialog = false;
                NewAY = string.Empty;
                IsEdit = false;

            }));
            }
            set { _ActionAYCommand = value; }
        }
        private RelayCommand<object> _EditCommand;

        public RelayCommand<object> EditCommand
        {
            get
            {
                return _EditCommand ?? (_EditCommand = new RelayCommand<object>((obj) =>
            {
                SelectedAccessYear = obj as AccessYear;
                IsEdit = true;
                NewAY = SelectedAccessYear?.AY;
                OpenDialog = true;
            }));
            }
            set { _EditCommand = value; }
        }
        private RelayCommand<object> _DeleteCommand;

        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return _DeleteCommand ?? (_DeleteCommand = new RelayCommand<object>((obj) =>
            {
                SelectedAccessYear = obj as AccessYear;
                var result = accessRepo.Delete(SelectedAccessYear.Id);
                if (!result.ResultSuccess)
                    HandlePopUp.ShowPopUp(result);
                else
                    LoadAccessYear();
            }));
            }
            set { _DeleteCommand = value; }
        }

        #endregion
    }
}
