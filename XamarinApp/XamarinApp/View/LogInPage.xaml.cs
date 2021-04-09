using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinApp.Model;
using Firebase.Database.Query;
using XamarinApp.LangResource;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();

            loginEntry.Placeholder = Resource.loginEntryPH;
            passEntry.Placeholder = Resource.passEntryPH;
            loginButton.Text = Resource.loginButtonT;
            regLabel.Text = Resource.regLabelT;
        }

        private async void OnLogButtonClicked(object sender, EventArgs e)
        {
            //RegUser();

            var userName = loginEntry.Text;
            var pass = passEntry.Text;

            var response = await CheckUser(userName, pass);

            if (response != null)
            {
                App.currentApp.GotLogged();
            }
            else
            {
                await this.DisplayAlert("Alert","Invalid login or password!","OK");
            }
        }

        async void RegUser()
        {
            await App.firebaseClient
                .Child("Users")
                .PostAsync(new User(){Id = 2, Login = "user3", Password = "111"});
        }
        async Task<User> CheckUser(string userName, string pass)
        {
            var gotted = (await App.firebaseClient
                .Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.Login == userName).Where(b => b.Object.Password == pass).FirstOrDefault();

            if (gotted != null)
            {
                var content = gotted.Object as User;
                return content;
            }
            else
                return null;
        }
    }
}