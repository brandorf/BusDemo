using System.Configuration;
using BusDemo.Publisher.ViewModels;
using BusDemo.Services;
using Ninject.Modules;

namespace BusDemo.Publisher.Integration
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<MainWindowViewModel>().ToSelf();

            Bind<IBusService>().To<BusService>()
                .WithConstructorArgument("kernel", Kernel)
                .WithConstructorArgument("busAddress", ConfigurationManager.AppSettings["BusAddress"])
                .WithConstructorArgument("queueName", ConfigurationManager.AppSettings["QueueName"])
                .WithConstructorArgument("username", ConfigurationManager.AppSettings["BusUser"])
                .WithConstructorArgument("password", ConfigurationManager.AppSettings["BusPass"]);
        }
    }
}