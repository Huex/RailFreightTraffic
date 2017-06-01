using MaterialDesignThemes.Wpf;
using RailFreightTraffic.Commands;
using RailFreightTraffic.Dialogs;
using RailFreightTraffic.Models.App;
using RailFreightTraffic.ViewModels.Database;
using RailFreightTraffic.ViewModels.Dialogs;
using RailFreightTraffic.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RailFreightTraffic.ViewModels
{
    class PageViewModel : BaseViewModel
    {
        private TypeDialogs _dialog;
        private object _items;
        private bool _isReadOnly;

        public object Items
        {
            get
            {
                return _items;
            }
            private set
            {
                if (_items == value) return;
                _items = value;
                RaisePropertyChanged("Items");
            }
        }

        public PageViewModel(TypeDialogs dialog, bool isReadOnly)
        {
            _isReadOnly = isReadOnly;
            _dialog = dialog;
            UpdateData();
        }

        public async void ExecuteRunEditData(object item)
        {
            switch (_dialog)
            {
                case (TypeDialogs.Client):
                    var view = new ClientDialog
                    {
                        DataContext = new ClientDialogViewModel((ClientData)item, _isReadOnly)
                    };
                    ((ClientDialogViewModel)view.DataContext).Edited += UpdateData;
                    view.Width = 300;
                    await DialogHost.Show(view, "RootDialog");
                    break;
                case (TypeDialogs.User):
                    var view2 = new UserDialog
                    {
                        DataContext = new UserDialogViewModel((UserData)item, _isReadOnly)
                    };
                    ((UserDialogViewModel)view2.DataContext).Edited += UpdateData;
                    view2.Width = 300;
                    await DialogHost.Show(view2, "RootDialog");
                    break;
                case (TypeDialogs.Content):
                    var view3 = new ContentDialog
                    {
                        DataContext = new ContentDialogViewModel((ContentsData)item, _isReadOnly)
                    };
                    ((ContentDialogViewModel)view3.DataContext).Edited += UpdateData;
                    view3.Width = 300;
                    await DialogHost.Show(view3, "RootDialog");
                    break;
                case (TypeDialogs.Station):
                    var view4 = new StationDialog
                    {
                        DataContext = new StationDialogViewModel((StationData)item, _isReadOnly)
                    };
                    ((StationDialogViewModel)view4.DataContext).Edited += UpdateData;
                    view4.Width = 300;
                    await DialogHost.Show(view4, "RootDialog");
                    break;
                case (TypeDialogs.Route):
                    var view5 = new RouteDialog
                    {
                        DataContext = new RouteDialogViewModel((RouteData)item, _isReadOnly)
                    };
                    ((RouteDialogViewModel)view5.DataContext).Edited += UpdateData;
                    view5.Width = 300;
                    await DialogHost.Show(view5, "RootDialog");
                    break;
                case (TypeDialogs.Cargo):
                    var view6 = new CargoDialog
                    {
                        DataContext = new CargoDialogViewModel((CargoData)item, _isReadOnly)
                    };
                    ((CargoDialogViewModel)view6.DataContext).Edited += UpdateData;
                    view6.Width = 300;
                    await DialogHost.Show(view6, "RootDialog");
                    break;
            }
        }

        private void UpdateData()
        {
            switch (_dialog)
            {
                case (TypeDialogs.Client):
                    Items = UserClient.LoadClients();
                    break;
                case (TypeDialogs.User):
                    Items = UserClient.LoadUsers();
                    break;
                case (TypeDialogs.Content):
                    Items = UserClient.LoadContents();
                    break;
                case (TypeDialogs.Station):
                    Items = UserClient.LoadStations();
                    break;
                case (TypeDialogs.Route):
                    Items = UserClient.LoadRoutes();
                    break;
                case (TypeDialogs.Cargo):
                    Items = UserClient.LoadCargos();
                    break;
            }
        }

        private ICommand _newRowCommand;

        public ICommand NewRowCommand
        {
            get
            {
                if (_newRowCommand == null)
                {
                    _newRowCommand = new DelegateCommand(NewRow);
                }
                return _newRowCommand;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
        }

        private async void NewRow()
        {
            switch (_dialog)
            {
                case (TypeDialogs.Client):
                    var view = new ClientDialog
                    {
                        DataContext = new ClientDialogViewModel()
                    };
                    ((ClientDialogViewModel)view.DataContext).Edited += UpdateData;
                    view.Width = 300;
                    await DialogHost.Show(view, "RootDialog");
                    break;
                case (TypeDialogs.User):
                    var view2 = new UserDialog
                    {
                        DataContext = new UserDialogViewModel()
                    };
                    ((UserDialogViewModel)view2.DataContext).Edited += UpdateData;
                    view2.Width = 300;
                    await DialogHost.Show(view2, "RootDialog");
                    break;
                case (TypeDialogs.Content):
                    var view3 = new ContentDialog
                    {
                        DataContext = new ContentDialogViewModel()
                    };
                    ((ContentDialogViewModel)view3.DataContext).Edited += UpdateData;
                    view3.Width = 300;
                    await DialogHost.Show(view3, "RootDialog");
                    break;
                case (TypeDialogs.Station):
                    var view4 = new StationDialog
                    {
                        DataContext = new StationDialogViewModel()
                    };
                    ((StationDialogViewModel)view4.DataContext).Edited += UpdateData;
                    view4.Width = 300;
                    await DialogHost.Show(view4, "RootDialog");
                    break;
                case (TypeDialogs.Route):
                    var view5 = new RouteDialog
                    {
                        DataContext = new RouteDialogViewModel()
                    };
                    ((RouteDialogViewModel)view5.DataContext).Edited += UpdateData;
                    view5.Width = 300;
                    await DialogHost.Show(view5, "RootDialog");
                    break;
                case (TypeDialogs.Cargo):
                    var view6 = new CargoDialog
                    {
                        DataContext = new CargoDialogViewModel()
                    };
                    ((CargoDialogViewModel)view6.DataContext).Edited += UpdateData;
                    view6.Width = 300;
                    await DialogHost.Show(view6, "RootDialog");
                    break;

            }
        }
    }
}
