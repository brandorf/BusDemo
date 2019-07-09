using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusDemo.ViewModels;
using Xamarin.Forms;

namespace BusDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel dataContext)
        {
            InitializeComponent();
            this.BindingContext = dataContext;
        }
    }
}
