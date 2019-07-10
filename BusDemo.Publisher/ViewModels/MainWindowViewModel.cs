using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BusDemo.Publisher.Annotations;
using BusDemo.Publisher.Integration;
using BusDemo.WPF;

namespace BusDemo.Publisher.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand _buttonClick;
        private string _name;

        public ICommand ButtonClick
        {
            get
            {
                if (_buttonClick == null)
                {
                    _buttonClick = new RelayCommand(
                        param => this.GenerateName()
                    );
                }
                return _buttonClick;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private void GenerateName()
        {
            var nameGen = new NameService();
            Name = nameGen.GetName();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}