using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinApp.LangResource;
using XamarinApp.Controller;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();

            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            tapGesture.Tapped += (s, e) =>
            {
                regLabel.TextColor = Color.FromHex("BF4A67");
                Navigation.PushModalAsync(new RegistryPage());
            };
            regLabel.GestureRecognizers.Add(tapGesture);

            ReTranslate();
        }

        private async void OnLogButtonClicked(object sender, EventArgs e)
        {
            var userName = loginEntry.Text;
            var pass = passEntry.Text;

            var response = await DBaseController.CheckUser(userName, pass);

            if (response != null)
            {
                App.currentApp.GotLogged();
            }
            else
            {
                await this.DisplayAlert("Alert","Invalid login or password!","OK");
            }
        }

        private void ReTranslate()
        {
            loginEntry.Placeholder = Resource.loginEntryPH;
            passEntry.Placeholder = Resource.passEntryPH;
            loginButton.Text = Resource.loginButtonT;
            regLabel.Text = Resource.regLabelT;
        }

        protected override void OnAppearing()
        {
            ReTranslate();
            regLabel.TextColor = Color.FromHex("3B3C3D");
        }

        //async void RegUser()
        //{
        //    await DBaseController.firebaseClient
        //        .Child("Users")
        //        .PostAsync(new User(){Id = 2, Login = "user3", Password = "111"});
        //}
    }
}