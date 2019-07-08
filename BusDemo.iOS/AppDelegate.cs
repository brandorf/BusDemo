using System;
using System.Collections.Generic;
using System.Linq;
using BusDemo.Integration;
using BusDemo.iOS.Integrations;
using Foundation;
using Ninject;
using UIKit;

namespace BusDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private StandardKernel _kernel;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var settings = new Ninject.NinjectSettings() { LoadExtensions = false, UseReflectionBasedInjection = true };
            _kernel = new StandardKernel(settings,
                new CommonBindings(),
                new IOSBindings()
                );

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(_kernel.Get<App>());

            return base.FinishedLaunching(app, options);
        }
    }
}
