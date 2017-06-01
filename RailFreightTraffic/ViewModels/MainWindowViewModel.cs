using RailFreightTraffic.Dialogs;
using RailFreightTraffic.Models.App;
using RailFreightTraffic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RailFreightTraffic.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(UserClient userClient)
        {

            ItemPages = new List<ItemPage>();
            ItemPages.Add(new ItemPage("Клиенты", new PageView() { DataContext = new PageViewModel(TypeDialogs.Client, !userClient.CurrentUser.Клиенты) }));
            ItemPages.Add(new ItemPage("Грузы", new PageView() { DataContext = new PageViewModel(TypeDialogs.Cargo, !userClient.CurrentUser.Грузы)  }));
            ItemPages.Add(new ItemPage("Продукты", new PageView() { DataContext = new PageViewModel(TypeDialogs.Content, !userClient.CurrentUser.Товары) }));
            ItemPages.Add(new ItemPage("Маршруты", new PageView() { DataContext = new PageViewModel(TypeDialogs.Route, !userClient.CurrentUser.Маршруты) }));
            ItemPages.Add(new ItemPage("Станции", new PageView() { DataContext = new PageViewModel(TypeDialogs.Station, !userClient.CurrentUser.Маршруты) }));

            if (userClient.CurrentUser.Пользователи)
            {
                ItemPages.Add(new ItemPage("Пользователи", new PageView() { DataContext = new PageViewModel(TypeDialogs.User, !userClient.CurrentUser.Пользователи) }));
            }
            //{
            //    new ItemPage("Clients", new PageView() {DataContext = new PageViewModel(TypeDialogs.Client) }),
            //    new ItemPage("Cargos", new PageView() {DataContext = new PageViewModel(TypeDialogs.Cargo) }),
            //    new ItemPage("Products", new PageView() {DataContext = new PageViewModel(TypeDialogs.Content) }),
            //    new ItemPage("Routes", new PageView() {DataContext = new PageViewModel(TypeDialogs.Route) }),
            //    new ItemPage("Users", new PageView() {DataContext = new PageViewModel(TypeDialogs.User) }),
            //};
        }
        public List<ItemPage> ItemPages { get; }
    }
}
