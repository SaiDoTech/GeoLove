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
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            AddUserInfo();
            ReColor();
        }

        private void ReColor()
        {
            this.BackgroundColor = ColorController.CurrentTheme.BackColor;

            userFrame.BorderColor = ColorController.CurrentTheme.AddColor;
            userFrame.BackgroundColor = ColorController.CurrentTheme.BackColor;

            userProfileLabel.BackgroundColor = ColorController.CurrentTheme.AddColor;
            userProfileLabel.TextColor = ColorController.CurrentTheme.BackColor;
        }

        private void AddUserInfo()
        {
            StackLayout frameStack = new StackLayout();
            ScrollView scrollView = new ScrollView();

            var photoFrame = new Frame()
            {
                BorderColor = ColorController.CurrentTheme.AddColor,
                BackgroundColor = ColorController.CurrentTheme.BackColor,
                WidthRequest = 0.45f * userFrame.Width,
                HeightRequest = 0.55f * userFrame.Height,
                Padding = new Thickness(5, 5, 5, 5)
            };

            var userPhoto = new Image();
            userPhoto.Source = new UriImageSource
            {
                CachingEnabled = false,
                Uri = new Uri("https://zachiska.com/wp-content/uploads/2020/07/e-girl-hairstyle.jpg")
            };
            userPhoto.Aspect = Aspect.AspectFill;
            photoFrame.Content = userPhoto;

            var infoFrame = new Frame()
            {
                BorderColor = ColorController.CurrentTheme.AddColor,
                BackgroundColor = ColorController.CurrentTheme.BackColor,
                Padding = new Thickness(10, 10, 10, 10)
            };

            StackLayout infoStack = new StackLayout();

            Label infoLabel = new Label()
            {
                TextColor = ColorController.CurrentTheme.FontColor,
                Text = "Profile's info",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center
            };
            infoStack.Children.Add(infoLabel);

            Label nameLabel = new Label()
            {
                TextColor = ColorController.CurrentTheme.FontColor,
                Text = "Name: " + UserController.CurrentUser.Name,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            infoStack.Children.Add(nameLabel);

            Label ageLabel = new Label()
            {
                TextColor = ColorController.CurrentTheme.FontColor,
                Text = "Age: " + "18",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            infoStack.Children.Add(ageLabel);

            Label genderLabel = new Label()
            {
                TextColor = ColorController.CurrentTheme.FontColor,
                Text = "Gender: " + UserController.CurrentUser.Gender.Title,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            infoStack.Children.Add(genderLabel);

            Label statusLabel = new Label()
            {
                TextColor = ColorController.CurrentTheme.FontColor,
                Text = "Status: " + "Active",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            infoStack.Children.Add(statusLabel);

            infoFrame.Content = infoStack;

            var mediaFrame = new Frame()
            {
                BorderColor = ColorController.CurrentTheme.AddColor,
                BackgroundColor = ColorController.CurrentTheme.BackColor,
                Padding = new Thickness(10, 10, 10, 10)
            };

            StackLayout mediaStack = new StackLayout();

            Label mediaLabel = new Label()
            {
                TextColor = ColorController.CurrentTheme.FontColor,
                Text = "Profile's Media",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center
            };
            mediaStack.Children.Add(mediaLabel);

            Label showLabel = new Label()
            {
                TextColor = ColorController.CurrentTheme.FontColor,
                Text = "Show all media",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            mediaStack.Children.Add(showLabel);

            mediaFrame.Content = mediaStack;

            frameStack.Children.Add(photoFrame);
            frameStack.Children.Add(infoFrame);
            frameStack.Children.Add(mediaFrame);

            scrollView.Content = frameStack;
            userFrame.Content = scrollView;
        }
    }
}