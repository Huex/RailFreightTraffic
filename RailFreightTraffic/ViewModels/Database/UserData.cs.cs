using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.ViewModels.Database
{
    public class UserData : BaseViewModel
    {
        private string _login;
        private string _password;

        private bool _chCargos;
        private bool _chUsers;
        private bool _chContents;
        private bool _chClients;
        private bool _chRoutes;
        private bool _chStations;


        private string _key;

        public void SetKey(string key)
        {
            _key = key;
        }

        public string GetKey()
        {
            return _key;
        }

        public string Логин
        {
            get { return _login; }
            set
            {
                if (_login == value) return;
                _login = value;
                RaisePropertyChanged("Login");
            }
        }

        public string Пароль
        {
            get { return _password; }
            set
            {
                if (_password == value) return;
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public bool Грузы
        {
            get
            {
                return _chCargos;
            }

            set
            {
                if (_chCargos == value) return;
                _chCargos = value;
                RaisePropertyChanged("ChCargos");
            }
        }

        public bool Пользователи
        {
            get
            {
                return _chUsers;
            }

            set
            {
                if (_chUsers == value) return;
                _chUsers = value;
                RaisePropertyChanged("ChUsers");
            }
        }

        public bool Товары
        {
            get
            {
                return _chContents;
            }

            set
            {
                if (_chContents == value) return;
                _chContents = value;
                RaisePropertyChanged("ChContents");
            }
        }

        public bool Клиенты
        {
            get
            {
                return _chClients;
            }

            set
            {
                if (_chClients == value) return;
                _chClients = value;
                RaisePropertyChanged("ChClients");
            }
        }

        public bool Маршруты
        {
            get
            {
                return _chRoutes;
            }

            set
            {
                if (_chRoutes == value) return;
                _chRoutes = value;
                RaisePropertyChanged("ChRoutes");
            }
        }

        public bool Станции
        {
            get
            {
                return _chStations;
            }

            set
            {
                if (_chStations == value) return;
                _chStations = value;
                RaisePropertyChanged("ChStations");
            }
        }
    }
}
