using RailFreightTraffic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RailFreightTraffic.Views
{
    /// <summary>
    /// Логика взаимодействия для ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Window
    {
        public ConnectWindow()
        {
            InitializeComponent();
        }

        private void FloatingPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((ConnectViewModel)DataContext).User.Password = FloatingPasswordBox.Password;
        }
    }
}
