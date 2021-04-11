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
    public partial class SettingsPage : ContentPage
    {
        public NoScrollTabbedPage ParentPage { get; set; }

        public SettingsPage()
        {
            InitializeComponent();

            LangPicker.Items.Add("English");
            LangPicker.Items.Add("Russian");
            LangPicker.Items.Add("Belorussian");
            LangPicker.SelectedIndex = 0;

            foreach (var theme in ColorController.AppThemes)
            {
                ThemePicker.Items.Add(theme.Title);
            }
            ThemePicker.SelectedIndex = 0;
        }

        private void ThemePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorController.ChangeTheme(ThemePicker.SelectedIndex);
            if (ParentPage != null)
                this.ParentPage.ReColor();
            OnAppearing();
        }

        protected override void OnAppearing()
        {
            InitColor();
        }

        private void InitColor()
        {
            this.BackgroundColor = ColorController.CurrentTheme.BackColor;
        }
    }
}