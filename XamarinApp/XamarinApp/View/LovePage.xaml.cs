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
            AddUserInfo();
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
            var photoFrame = new Frame()
            {
                BorderColor = ColorController.CurrentTheme.AddColor,
                BackgroundColor = ColorController.CurrentTheme.BackColor,
                WidthRequest = 0.45f * userFrame.Width,
                HeightRequest = 0.55f * userFrame.Height,
                Padding =  new Thickness(5, 5, 5, 5)
            };

            var userPhoto = new Image();
            userPhoto.Source = new UriImageSource
            {
                CachingEnabled = false,
                Uri = new Uri("https://zachiska.com/wp-content/uploads/2020/07/e-girl-hairstyle.jpg")
            };
            userPhoto.Aspect = Aspect.AspectFill;
            photoFrame.Content = userPhoto;

            Label nameAgeLabel = new Label()
            {
                Text = UserController.CurrentUser.Name + ", " + UserController.CurrentUser.Age,
                TextColor = ColorController.CurrentTheme.FontColor,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label distanceLabel = new Label()
            {
                Text = "Distance: 200m",
                TextColor = ColorController.CurrentTheme.FontColor,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var stack = new StackLayout();
            stack.Children.Add(photoFrame);
            stack.Children.Add(nameAgeLabel);
            stack.Children.Add(distanceLabel);

            userFrame.Content = stack;

            SwipeItem leftItem = new SwipeItem
            {
                Text = "Skip",
                BackgroundColor = ColorController.CurrentTheme.FontColor
            };
            leftItem.Invoked += OnInvoked1;
            SwipeItem rightItem = new SwipeItem
            {
                Text = "Like",
                BackgroundColor = ColorController.CurrentTheme.AddColor
            };
            rightItem.Invoked += OnInvoked2;

            SwipeItems leftItems = new SwipeItems(new List<SwipeItem>() { leftItem });
            leftItems.Mode = SwipeMode.Execute;

            SwipeItems rightItems = new SwipeItems(new List<SwipeItem>() { rightItem });
            rightItems.Mode = SwipeMode.Execute;

            swipeView.LeftItems = leftItems;
            swipeView.RightItems = rightItems;
        }

        private void OnInvoked1(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Skipped", "OK");
        }

        private void OnInvoked2(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Licked", "OK");
        }
    }
}