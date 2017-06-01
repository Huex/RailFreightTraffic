using MaterialDesignThemes.Wpf;
using RailFreightTraffic.Dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RailFreightTraffic.Views
{
    /// <summary>
    /// Логика взаимодействия для BaseView.xaml
    /// </summary>
    public partial class PageView : UserControl
    {
        public PageView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Ensure row was clicked and not empty space
            DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null) return;
            ((PageViewModel)DataContext).ExecuteRunEditData(row.Item);

           
        }
    }
}
