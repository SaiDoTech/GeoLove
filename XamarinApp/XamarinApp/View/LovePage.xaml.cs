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
    public partial class LovePage : ContentPage
    {
        public LovePage()
        {
            InitializeComponent();
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