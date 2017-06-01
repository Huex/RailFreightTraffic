using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.App
{
    public class ConnectionStatus : INotifyPropertyChanged
    { 
        public ConnectionState State { get; private set; }
        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }

        public ConnectionStatus(ConnectionState state)
        {
            Set(state);
        }

        public ConnectionStatus(ConnectionState state, string errorMessage)
        {
            Set(state, errorMessage);
        }

        public void Set(ConnectionState state)
        {
            State = state;
            HasError = false;
            ErrorMessage = null;
            OnPropertyChanged("State");
        }

        public void Set(ConnectionState state, string errorMessage)
        {
            State = state;
            HasError = true;
            ErrorMessage = errorMessage;
            OnPropertyChanged("State");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
