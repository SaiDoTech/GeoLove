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
            profileLabel.BackgroundColor = ColorController.CurrentTheme.AddColor;
            profileLabel.TextColor = ColorController.CurrentTheme.BackColor;

            userFrame.BackgroundColor = ColorController.CurrentTheme.BackColor;
            userFrame.BorderColor = ColorController.CurrentTheme.AddColor;
        }

        private void AddUserInfo()
        {
            var stack = new StackLayout();

            var photoFrame = new Frame();

            var userPhoto = new Image();
            userPhoto.Source = new UriImageSource
            {
                CachingEnabled = false,
                Uri = new Uri("https://zachiska.com/wp-content/uploads/2020/07/e-girl-hairstyle.jpg")
            };
            userPhoto.Aspect = Aspect.AspectFill;
            photoFrame.Content = userPhoto;

            stack.Children.Add(photoFrame);

            userFrame.Content = stack;
        }
    }
}