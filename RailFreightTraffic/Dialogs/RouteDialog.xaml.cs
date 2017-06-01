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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RailFreightTraffic.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для RouteDialog.xaml
    /// </summary>
    public partial class RouteDialog : UserControl
    {
        public RouteDialog()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            ((RouteDialogViewModel)DataContext).Edit();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            ((RouteDialogViewModel)DataContext).Delete();
        }
    }
}
