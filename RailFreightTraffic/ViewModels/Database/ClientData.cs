using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.ViewModels.Database
{
    public class ClientData : BaseViewModel
    {       
        private string _name;
        private string _surname;
        private string _company;

        private string _key;

        public void SetKey(string key)
        {
            _key = key;
            RaisePropertyChanged("Key");
        }

        public string GetKey()
        {
            return _key;
        }

        public string Имя
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Фамилия
        {
            get { return _surname; }
            set
            {
                if (_surname == value) return;
                _surname = value;
                RaisePropertyChanged("Surname");
            }
        }

        public string Компания
        {
            get { return _company; }
            set
            {
                if (_company == value) return;
                _company = value;
                RaisePropertyChanged("Company");
            }
        } 
    }
}
