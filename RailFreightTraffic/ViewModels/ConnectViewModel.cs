using RailFreightTraffic.Commands;
using RailFreightTraffic.Models.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RailFreightTraffic.ViewModels
{
    public class ConnectViewModel : BaseViewModel
    {
        public Credentials User { get; set; }
        public string Prompt { get; private set; }
        private UserClient _client;

        private ICommand _connectCommand;

        public ICommand ConnectCommand
        {
            get
            {
                if (_connectCommand == null)
                {
                    _connectCommand = new DelegateCommand(Connect);
                }
                return _connectCommand;
            }
        }

        public ConnectionStatus ConnectionStatus
        {
            get
            {
                return _client.ConnectionStatus;
            }
        }

        public ConnectViewModel(UserClient client)
        {
            _client = client;
            User = new Credentials();
            _client.ConnectionStatus.PropertyChanged += (p, s) => { RaisePropertyChanged("ConnectionStatus"); };
        }

        private void Connect()
        {
            _client.Connect(User);
        }

    }
}
