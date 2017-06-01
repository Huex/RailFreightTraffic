using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.ViewModels.Database
{
    public class CargoData : BaseViewModel
    {
        private string _client;
        private string _route;
        private string _content;
        private string _date;

        private string _key;

        public void SetKey(string key)
        {
            _key = key;
        }

        public string GetKey()
        {
            return _key;
        }

        public string Клиент
        {
            get { return _client; }
            set
            {
                if (_client == value) return;
                _client = value;
                RaisePropertyChanged("Client");
            }
        }

        public string Маршрут
        {
            get { return _route; }
            set
            {
                if (_route == value) return;
                _route = value;
                RaisePropertyChanged("Route");
            }
        }

        public string Товар
        {
            get { return _content; }
            set
            {
                if (_content == value) return;
                _content = value;
                RaisePropertyChanged("Content");
            }
        }

        public string Дата
        {
            get { return _date; }
            set
            {
                if (_date == value) return;
                _date = value;
                RaisePropertyChanged("Date");
            }
        }
    }
}
