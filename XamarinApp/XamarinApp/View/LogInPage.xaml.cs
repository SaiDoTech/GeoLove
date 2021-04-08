using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinApp.Model;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        FirebaseClient firebaseClient;

        public LogInPage()
        {
            firebaseClient = new FirebaseClient("https://geolovemaps-default-rtdb.firebaseio.com/");

            InitializeComponent();
        }

        private void OnLogButtonClicked(object sender, EventArgs e)
        {
            RegUser();
            //App.currentApp.GotLogged();
        }

        async void RegUser()
        {
            await firebaseClient
                .Child("Users")
                .PostAsync(new User(){Id = 0, Login = "user", Password = "123"});
        }
    }
}