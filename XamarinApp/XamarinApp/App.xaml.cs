using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.View;

using XamarinApp.Model;
using XamarinApp.Controller;

namespace XamarinApp
{
    public partial class App : Application
    {
        public static App currentApp { get; private set; }

        public App()
        {
            currentApp = this;
            var dbase = new DBaseController("https://geolovemaps-default-rtdb.firebaseio.com/");

            MainPage = new LogInPage();

            InitializeComponent();
        }

        public void GotLogged()
        {
            MainPage = new NoScrollTabbedPage();
        }
    }
}
