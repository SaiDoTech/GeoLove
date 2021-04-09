using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.View;

using Firebase.Database;
using XamarinApp.Model;

namespace XamarinApp
{
    public partial class App : Application
    {
        public static App currentApp { get; private set; }
        public static FirebaseClient firebaseClient { get; private set; }

        public App()
        {
            currentApp = this;
            firebaseClient = new FirebaseClient("https://geolovemaps-default-rtdb.firebaseio.com/");

            MainPage = new LogInPage();

            InitializeComponent();
        }

        public void GotLogged()
        {
            MainPage = new NoScrollTabbedPage();
        }
    }
}
