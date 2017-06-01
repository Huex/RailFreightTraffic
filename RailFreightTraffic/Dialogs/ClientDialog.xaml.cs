using RailFreightTraffic.ViewModels.Dialogs;
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

namespace RailFreightTraffic.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientDialog.xaml
    /// </summary>
    public partial class ClientDialog : UserControl
    {
        public ClientDialog()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            ((ClientDialogViewModel)DataContext).Edit();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            ((ClientDialogViewModel)DataContext).Delete();
        }
    }
}
