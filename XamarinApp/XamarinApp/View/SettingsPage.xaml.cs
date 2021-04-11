using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Controller;
using XamarinApp.LangResource;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public NoScrollTabbedPage ParentPage { get; set; }

        public SettingsPage()
        {
            InitializeComponent();

            foreach (var language in LanguageController.AppLanguages)
            {
                LangPicker.Items.Add(language.Title);
            }
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
            ReColor();
        }

        private void ReColor()
        {
            this.BackgroundColor = ColorController.CurrentTheme.BackColor;

            settingsLabel.TextColor = ColorController.CurrentTheme.FontColor;
            LangPicker.TextColor = ColorController.CurrentTheme.FontColor;
            LangLabel.TextColor = ColorController.CurrentTheme.FontColor;
            themeLabel.TextColor = ColorController.CurrentTheme.FontColor;
            ThemePicker.TextColor = ColorController.CurrentTheme.FontColor;
        }

        private void LangPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageController.SetNewCulture(LangPicker.SelectedIndex);
            ReTranslate();
        }

        private void ReTranslate()
        {
            settingsLabel.Text = Resource.settingsLabelT;
        }
    }
}