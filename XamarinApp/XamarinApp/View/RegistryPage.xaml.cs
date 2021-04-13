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
                var response =  await UserController.CreateNewUser(login, pass, name, dob, gender);
                if (response)
                {
                    await DisplayAlert("Congratulation!", "Successful registry!", "OK!");
                    await Navigation.PopModalAsync();
                }
                else
                    throw new Exception("Something went wrong!");
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