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
                if (_buttonClick == null)
                {
                    _buttonClick = new RelayCommand(
                        async param => await this.GenerateName()
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

        private async Task GenerateName()
        {
            var nameGen = new NameService();
            Name = nameGen.GetName();

            var message = new SendName()
            {
                Name = this.Name
            };

            await _bus.Send<SendName>(message);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}