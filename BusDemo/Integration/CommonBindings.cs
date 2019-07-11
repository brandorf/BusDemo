using System;
using BusDemo.Services;
using Ninject;
using Ninject.Modules;
using Xamarin.Forms;

namespace BusDemo.Integration
{
    public class CommonBindings : NinjectModule
    {
        public override void Load()
        {

            Bind<IBusService>().To<BusService>()
                .WithConstructorArgument("kernel", Kernel)
                .WithConstructorArgument("busAddress", AppSettingsManager.Settings["BusAddress"])
                .WithConstructorArgument("queueName", AppSettingsManager.Settings["QueueName"])
                .WithConstructorArgument("username", AppSettingsManager.Settings["BusUser"])
                .WithConstructorArgument("password", AppSettingsManager.Settings["BusPass"]);

            Bind<Page>().To<MainPage>().WhenInjectedInto(typeof(App));
            
        }
    }
}
