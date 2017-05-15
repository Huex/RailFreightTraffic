using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.App
{
    public class Client
    {
        private Credentials _userCredentials;
        public ConnectionStatus ConnectionStatus { get; private set; }

        public Client()
        {
            ConnectionStatus = new ConnectionStatus(ConnectionState.Disconnected);
        }

        public async void Connect(Credentials user)
        {
            _userCredentials = user;
            ConnectionStatus.Set(ConnectionState.Connecting);
            var result = await Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                return "Результат обработки";
            });

            if(_userCredentials.Account == "123" && _userCredentials.Password == "123")
            {
                ConnectionStatus.Set(ConnectionState.Connected);
            }
            else
            {
                ConnectionStatus.Set(ConnectionState.Disconnected, "Wrong login or password");
            }

        }
    }
}
