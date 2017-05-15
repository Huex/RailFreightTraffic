using RailFreightTraffic.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RailFreightTraffic.Converters.ConnectWindow
{
    internal class ConnectButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (((ConnectionStatus)value).State)
            {
                case (ConnectionState.Connecting):
                    return Visibility.Hidden;
                case (ConnectionState.Disconnected):
                    return Visibility.Visible;
                case (ConnectionState.Connected):
                    return Visibility.Hidden;
                case (ConnectionState.Disconnecting):
                    return Visibility.Hidden;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
