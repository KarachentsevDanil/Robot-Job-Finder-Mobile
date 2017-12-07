using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJF.MobileApp.Pages.Layouts;
using Xamarin.Forms;

namespace RJF.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainLayoutPage();
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}
