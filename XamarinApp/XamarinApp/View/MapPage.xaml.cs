using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            Map map = new Map();

            Pin pin = new Pin();
            pin.Label = "UserLabel";

            map.Pins.Add(pin);

            Content = map;

            InitializeComponent();
        }
    }
}