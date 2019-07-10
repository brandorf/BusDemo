using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BusDemo.Publisher.Integration;
using Ninject;

namespace BusDemo.Publisher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal StandardKernel Kernel { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            Kernel = new StandardKernel(
                new Bindings()
            );
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.Kernel.Get<MainWindow>();
        }
    }
}
