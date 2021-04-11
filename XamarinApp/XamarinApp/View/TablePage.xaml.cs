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
    public partial class TablePage : ContentPage
    {
        public TablePage()
        {
            InitializeComponent();
            InitPage();
        }

        private async void InitPage()
        {
            var temp = await DBaseController.GetUsers();

            foreach (var item in temp)
            {
                var lol = new Label
                {
                    Text = item.Login
                };
                TableStack.Children.Add(lol);
            }
        }
    
        protected override void OnAppearing()
        {
            ReColor();
        }   

        private void ReColor()
        {
            this.BackgroundColor = ColorController.CurrentTheme.BackColor;
        }
    }
}