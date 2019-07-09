using System;
using Ninject;
using Ninject.Modules;

namespace BusDemo.Integration
{
    public class CommonBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<App>().To<App>().WithConstructorArgument("mainPage", Kernel.Get<MainPage>());
        }
    }
}
