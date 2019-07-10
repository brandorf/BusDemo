using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BusDemo.Integration;
using BusDemo.WPF.Integration;
using Ninject;

namespace BusDemo.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static StandardKernel Kernel { get; private set; }

        public App()
        {
            Kernel = new StandardKernel(
                new CommonBindings(),
                new WPFBindings()
            );
        }
    }
}
