using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BusDemo.Annotations;
using BusDemo.Services;

namespace BusDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly BusService _bus;

        public MainViewModel(BusService bus)
        {
            _bus = bus;
        }

        private bool _isBroken;
        private bool _connected;
        private string _connectionName;
        private string _messages;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBroken
        {
            get { return _isBroken; }
            set
            {
                if (value == _isBroken) return;
                _isBroken = value;
                OnPropertyChanged();
            }
        }

        public bool Connected
        {
            get => _connected;
            set
            {
                if (value == _connected) return;
                _connected = value;
                OnPropertyChanged();
                if(value)
                    ConnectToBus(_connectionName);
                else
                {
                    DisconnectFromBus();
                }
            }
        }

        private void DisconnectFromBus()
        {
            _bus.Stop();
        }

        private void ConnectToBus(string connectionName)
        {
            _bus.Start(connectionName);
        }

        public string ConnectionName
        {
            get => _connectionName;
            set
            {
                if (value == _connectionName) return;
                _connectionName = value;
                OnPropertyChanged();
            }
        }

        public string Messages
        {
            get => _messages;
            set
            {
                if (value == _messages) return;
                _messages = value;
                OnPropertyChanged();
            }
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
