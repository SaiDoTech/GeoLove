using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Controller;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistryPage : ContentPage
    {
        private DateTime selectedDate;

        public RegistryPage()
        {
            InitializeComponent();
            genderPicker.SelectedIndex = 0;
        }

        private async void registryButton_ClickedAsync(object sender, EventArgs e)
        {
            var login = loginEntry.Text;
            var pass = passEntry.Text;
            var name = nameEntry.Text;
            var gender = GenderController.AppGenders[genderPicker.SelectedIndex];
            var dob = selectedDate;

            try
            {
                var response = await DBaseController.IsLoginFree(login);

                if (response)
                {
                    var id = await DBaseController.GetUsersCount();
                    id++;

                    var user = new Model.User(id, login, pass, name, dob, gender);

                    var registered = await DBaseController.RegUser(user);
                    if (registered)
                    {
                        await DisplayAlert("Congratulation!", "Successful registry!", "OK!");
                        await Navigation.PopModalAsync();
                    }
                    else
                        throw new Exception("Something went wrong!");
                }
                else
                    throw new Exception("Sorry, but this login is already taken!");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert!", ex.Message, "OK!");
            }
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            selectedDate = e.NewDate;
        }
    }
}