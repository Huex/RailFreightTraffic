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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserDialog : UserControl
    {
        public UserDialog()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            ((UserDialogViewModel)DataContext).Edit();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            ((UserDialogViewModel)DataContext).Delete();
        }
    }
}
