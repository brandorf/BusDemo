using BusDemo.Publisher.ViewModels;
using Ninject.Modules;

namespace BusDemo.Publisher.Integration
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<MainWindowViewModel>().ToSelf();
        }
    }
}