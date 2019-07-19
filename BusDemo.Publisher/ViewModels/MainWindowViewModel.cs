using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using BusDemo.Messages;
using BusDemo.Publisher.Annotations;
using BusDemo.Publisher.Integration;
using BusDemo.Services;

namespace BusDemo.Publisher.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IBusService _bus;

        public MainWindowViewModel(IBusService bus)
        {
            _bus = bus;
            _bus.Start("Publisher");
        }

        private ICommand _buttonClick;
        private string _name;

        public ICommand ButtonClick
        {
            get
            {
                return _buttonClick ?? (_buttonClick = new RelayCommand(
                           async param => await this.GenerateNameAsync()
                       ));
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

        private async Task GenerateNameAsync()
        {
            var nameGen = new NameService();
            Name = nameGen.GetName();
            await _bus.Send(new SendName(Name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}