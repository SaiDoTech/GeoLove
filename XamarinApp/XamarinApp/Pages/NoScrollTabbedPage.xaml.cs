using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages
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
        }
    }
}