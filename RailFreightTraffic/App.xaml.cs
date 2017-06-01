using RailFreightTraffic.Models.App;
using RailFreightTraffic.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RailFreightTraffic
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        UserClient _userClient;
        private void OnStartup(object sender, StartupEventArgs e)
        {
            _userClient = new UserClient();
           ConnectWindow connectWindow = new ConnectWindow(_userClient);

            _userClient.ConnectionStatus.PropertyChanged += (s, p) =>
            {
                if (_userClient.ConnectionStatus.State == Models.App.ConnectionState.Connected && !_userClient.ConnectionStatus.HasError)
                {
                    OnLogin();
                    connectWindow.Close();         
                }
            };
          
            connectWindow.Show();
        }

        private void OnLogin()
        {
            MainWindow view = new MainWindow(_userClient);
            view.Show();
        }
    }
}
