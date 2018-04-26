using DAL.EDMX;
using DAL.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JSP.Util;
using System;
using System.Collections.ObjectModel;
namespace JSP.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        private ClientRepository clientRepo;
        public DashboardViewModel()
        {
            Timer.Tick += (ea, sa) =>
            {
                TodayTime = string.Format("{0:hh:mm:ss tt}", DateTime.Now);
            };
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            clientRepo = new ClientRepository();
            App.ContainerVM.AYMenuVisbility = System.Windows.Visibility.Visible;
        }
        #region Properties
        private string _TodayTime;

        public string TodayTime
        {
            get { return _TodayTime; }
            set { _TodayTime = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Client> _Clients;

        public ObservableCollection<Client> Clients
        {
            get { return _Clients ?? (_Clients = new ObservableCollection<Client>()); }
            set { _Clients = value; RaisePropertyChanged(); }
        }


        public string Today
        {
            get { return string.Format("{0:dd-MMM-yyyy}", DateTime.Now); }
        }

        private string _SelectedReturnType;

        public string SelectedReturnType
        {
            get { return _SelectedReturnType; }
            set { _SelectedReturnType = value; RaisePropertyChanged(); }
        }

        #endregion
        #region PrivateMethods
        private void LoadClietns(int returntypeid)
        {
            try
            {
                Clients = clientRepo.GetAll(returntypeid).ToObservableCollection();
            }
            catch (Exception ex)
            {

                Log4Net.WriteException(ex);
            }
        }
        #endregion

        #region Commands
        private RelayCommand<object> _LoadClientsCommand;

        public RelayCommand<object> LoadClientsCommand
        {
            get
            {
                return _LoadClientsCommand ?? (_LoadClientsCommand = new RelayCommand<object>((obj) =>
            {
                if (obj.ToString() == "1")
                    SelectedReturnType = "Selected Return Type :IT";
                else
                    SelectedReturnType = "Selected Return Type :GST";
                LoadClietns(Convert.ToInt32(obj));

            }));
            }
            set { _LoadClientsCommand = value; }
        }


        #endregion
    }
}
