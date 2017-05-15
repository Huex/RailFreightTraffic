using RailFreightTraffic.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RailFreightTraffic.Converters.ConnectWindow
{
    internal class ConnectFieldsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (((ConnectionStatus)value).State)
            {
                case (ConnectionState.Connecting):
                    return false;
                case (ConnectionState.Disconnected):
                    return true;
                case (ConnectionState.Connected):
                    return false;
                case (ConnectionState.Disconnecting):
                    return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
