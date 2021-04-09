using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            LangPicker.Items.Add("English");
            LangPicker.Items.Add("Russian");
            LangPicker.Items.Add("Belorussian");
            LangPicker.SelectedIndex = 0;

            ThemePicker.Items.Add("Light");
            ThemePicker.Items.Add("Dark");
            ThemePicker.SelectedIndex = 0;
        }
    }
}