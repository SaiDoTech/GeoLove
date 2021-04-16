using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using XamarinApp.Controller;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoScrollTabbedPage : Xamarin.Forms.TabbedPage
    {
        public NoScrollTabbedPage()
        {
            InitializeComponent();

            this.CurrentPage = this.Children[2];

            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            settingsPage.ParentPage = this;
        }

        public void ReColor()
        {
            this.BarBackgroundColor = ColorController.CurrentTheme.BackColor;
            this.SelectedTabColor = ColorController.CurrentTheme.AddColor;
            this.UnselectedTabColor = ColorController.CurrentTheme.FontColor;
        }

        protected override void OnAppearing()
        {
            ReColor();
        }
    }
}