using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.View;

namespace XamarinApp
{
    public partial class App : Application
    {
        public static App currentApp { get; private set; }

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
    }
}
