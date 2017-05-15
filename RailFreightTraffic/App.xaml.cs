using RailFreightTraffic.Models.App;
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
        private void OnStartup(object sender, StartupEventArgs e)
        {
            Client BDClient = new Client();
            Views.ConnectWindow connectWindow = new Views.ConnectWindow();
            connectWindow.DataContext = new ViewModels.ConnectViewModel(BDClient);

            BDClient.ConnectionStatus.PropertyChanged += (s, p) =>
            {
                if (BDClient.ConnectionStatus.State == Models.App.ConnectionState.Connected && !BDClient.ConnectionStatus.HasError)
                {
                    OnLogin();
                    connectWindow.Close();         
                }
            };
          
            connectWindow.Show();
        }

        private void OnLogin()
        {
            Views.MainWindow view = new Views.MainWindow();
            view.Show();
        }
    }
}
