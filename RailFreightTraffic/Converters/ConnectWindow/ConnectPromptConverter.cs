using RailFreightTraffic.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RailFreightTraffic.Converters.ConnectWindow
{
    internal class ConnectPromptConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((ConnectionStatus)value).HasError)
            {
                return ((ConnectionStatus)value).ErrorMessage;
            }else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
