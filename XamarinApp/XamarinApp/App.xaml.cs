using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Pages;

namespace XamarinApp
{
    public partial class App : Application
    {
        public static App currentApp;

        public App()
        {
            currentApp = this;
            MainPage = new LogInPage();

            InitializeComponent();
        }

        public void GotLogged()
        {
            MainPage = new NoScrollTabbedPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
