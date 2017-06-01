using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.ViewModels.Database
{
    public class StationData : BaseViewModel
    {
        private string _name;

        private string _key;

        public void SetKey(string key)
        {
            _key = key;
        }

        public string GetKey()
        {
            return _key;
        }

        public string Наименование
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
    }
}
