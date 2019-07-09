using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BusDemo.Annotations;

namespace BusDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {

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
            }
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
