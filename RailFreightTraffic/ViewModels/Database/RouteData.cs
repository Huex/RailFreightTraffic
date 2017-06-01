using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.ViewModels.Database
{
    public class RouteData : BaseViewModel
    {
        private string _start;
        private string _finish;
        private string _price;

        private string _key;

        public void SetKey(string key)
        {
            _key = key;
        }

        public string GetKey()
        {
            return _key;
        }

        public string Начальная
        {
            get { return _start; }
            set
            {
                if (_start == value) return;
                _start = value;
                RaisePropertyChanged("Start");
            }
        }
        public string Конечная
        {
            get { return _finish; }
            set
            {
                if (_finish == value) return;
                _finish = value;
                RaisePropertyChanged("Finish");
            }
        }
        public string Цена
        {
            get { return _price; }
            set
            {
                if (_price == value) return;
                _price = value;
                RaisePropertyChanged("Price");
            }
        }
    }
}
