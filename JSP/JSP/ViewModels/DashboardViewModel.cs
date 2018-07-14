using DAL.EDMX;
using DAL.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JSP.Util;
using JSP.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

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
            FilterColumn.Add(string.Empty);
            FilterColumn.Add("PanCard");
            FilterColumn.Add("Name");

            Messenger.Default.Register<AddClientViewModel>(this, (send) =>
            {
                LoadClietns();
            });

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
        private string _SearchClient;

        public string SearchClient
        {
            get { return _SearchClient; }
            set
            {
                _SearchClient = value;
                RaisePropertyChanged();

            }
        }
        private ObservableCollection<string> _FilterColumn;

        public ObservableCollection<string> FilterColumn
        {
            get { return _FilterColumn ?? (_FilterColumn = new ObservableCollection<string>()); }
            set { _FilterColumn = value; RaisePropertyChanged(); }
        }
        private string _SelectedFilter;

        public string SelectedFilter
        {
            get { return _SelectedFilter; }
            set { _SelectedFilter = value; RaisePropertyChanged(); }
        }
        private Visibility _isSearch = Visibility.Collapsed;

        public Visibility isSearch
        {
            get { return _isSearch; }
            set { _isSearch = value; RaisePropertyChanged(); }
        }


        public int SelectedReturnTypeId { get; set; }
        public int OffSet { get; set; } = 0;
        public bool IsFilter { get; set; } = false;
        public int Page { get; set; } = 0;
        public int TotalClients { get; set; }

        #endregion
        #region PrivateMethods
        private async void LoadClietns()
        {
            try
            {
                App.ContainerVM.IsBusy = true;
                await Task.Run(() =>
                {
                    IsFilter = false;
                    var clients = clientRepo.GetAll(SelectedReturnTypeId, OffSet, TotalClients <= 0);
                    Clients = clients.Clients.ToObservableCollection();
                    if (TotalClients <= 0)
                        TotalClients = clients.TotalCount;
                    App.ContainerVM.IsBusy = false;
                });


            }
            catch (Exception ex)
            {

                Log4Net.WriteException(ex);
            }
        }
        private async void LoadClientsByFilter()
        {
            try
            {
                App.ContainerVM.IsBusy = true;
                await Task.Run(() =>
                {
                    IsFilter = true;
                    var clients = clientRepo.GetByFilter(SelectedReturnTypeId, SelectedFilter, SearchClient, OffSet, TotalClients <= 0);
                    Clients = clients.Clients.ToObservableCollection();
                    if (TotalClients <= 0)
                        TotalClients = clients.TotalCount;
                    App.ContainerVM.IsBusy = false;
                });


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
                OffSet = 0;
                Page = 0;
                TotalClients = 0;
                SelectedFilter = string.Empty;
                SearchClient = string.Empty;
                if (obj.ToString() == "1")
                    SelectedReturnType = "Selected Return Type :IT";
                else
                    SelectedReturnType = "Selected Return Type :GST";

                SelectedReturnTypeId = Convert.ToInt32(obj);
                isSearch = Visibility.Visible;
                LoadClietns();
                PreviousCommand.RaiseCanExecuteChanged();
                NextCommand.RaiseCanExecuteChanged();


            }));
            }
            set { _LoadClientsCommand = value; }
        }
        private RelayCommand _SearchClientCommand;

        public RelayCommand SearchClientCommand
        {
            get
            {
                return _SearchClientCommand ?? (_SearchClientCommand = new RelayCommand(() =>
            {
                if (string.IsNullOrEmpty(SelectedFilter) && string.IsNullOrEmpty(SearchClient))
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Please enter require details for search");
                }
                else
                {
                    OffSet = 0;
                    Page = 0;
                    TotalClients = 0;
                    LoadClientsByFilter();
                    PreviousCommand.RaiseCanExecuteChanged();
                    NextCommand.RaiseCanExecuteChanged();
                }
            }));
            }
            set { _SearchClientCommand = value; }
        }

        private RelayCommand _PreviousCommand;

        public RelayCommand PreviousCommand
        {
            get
            {
                return _PreviousCommand ?? (_PreviousCommand = new RelayCommand(() =>
            {
                OffSet = (Page - 1) * 10;
                if (IsFilter)
                {
                    LoadClientsByFilter();
                }
                else
                {
                    LoadClietns();

                }
                Page--;
                PreviousCommand.RaiseCanExecuteChanged();
                NextCommand.RaiseCanExecuteChanged();
            }, CanPrevious));
            }
            set { _PreviousCommand = value; }
        }
        private bool CanPrevious()
        {
            if (Page > 0)
                return true;
            else
                return false;
        }
        private RelayCommand _NextCommand;

        public RelayCommand NextCommand
        {
            get
            {
                return _NextCommand ?? (_NextCommand = new RelayCommand(() =>
            {

                OffSet = (Page + 1) * 10;
                if (IsFilter)
                {
                    LoadClientsByFilter();
                }
                else
                {
                    LoadClietns();

                }
                Page++;
                PreviousCommand.RaiseCanExecuteChanged();
                NextCommand.RaiseCanExecuteChanged();
            }, CanNext));
            }
            set { _NextCommand = value; }
        }
        private RelayCommand<object> _SelectedClientCommand;

        public RelayCommand<object> SelectedClientCommand
        {
            get { return _SelectedClientCommand ?? (_SelectedClientCommand=new RelayCommand<object>((obj)=> 
            {
                var client = obj as Client;
                GenerateInvoiceViewModel vm = new GenerateInvoiceViewModel(client);
                GenerateInvoice invoice = new GenerateInvoice();
                invoice.DataContext = vm;
                App.ContainerVM.Content = invoice;
            })); }
            set { _SelectedClientCommand = value; }
        }

        private bool CanNext()
        {
            if (SelectedReturnTypeId != 0 && TotalClients > 10 && Clients.Count != 0 && ((Page + 1) * 10) <= TotalClients)
                return true;
            else
                return false;
        }

        #endregion
    }
}
