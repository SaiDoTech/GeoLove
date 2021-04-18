using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using XamarinApp.Controller;

namespace XamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        private StackLayout frameStack = new StackLayout()
        {
            Padding = new Thickness(10,10,10,10)
        };

        public TablePage()
        {
            InitializeComponent();
            InitPage();
            ReColor();
        }

        private async void InitPage()
        {
            var temp = await DBaseController.GetAllUsers();

            sortPicker.Items.Add("Sort by age");
            sortPicker.Items.Add("Sort by Distance");
            sortPicker.SelectedIndex = 0;
        }
    
        protected override void OnAppearing()
        {
            ReColor();

            ShowLikedUsers();
        }   

        private void ReColor()
        {
            this.BackgroundColor = ColorController.CurrentTheme.BackColor;
            upStack.BackgroundColor = ColorController.CurrentTheme.AddColor;
            sortPicker.TextColor = ColorController.CurrentTheme.BackColor;
            frameStack.BackgroundColor = ColorController.CurrentTheme.BackColor;
        }

        private void ShowLikedUsers()
        {
            frameStack.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                var frame = new Frame();

                frame.Padding = new Thickness(5,5,5,5);
                frame.BorderColor = ColorController.CurrentTheme.AddColor;
                frame.BackgroundColor = ColorController.CurrentTheme.BackColor;

                var grid = new Grid()
                {
                    RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(0.4f, GridUnitType.Star)}
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = new GridLength(0.25f, GridUnitType.Star ) },
                        new ColumnDefinition{ Width = new GridLength(0.75f, GridUnitType.Star ) },
                    }
                };

                var userInfo = new StackLayout();
                userInfo.Margin = new Thickness(5,0,0,0);
                userInfo.Spacing = 0.5f;

                var nameAgeLabel = new Label()
                {
                    Text = UserController.CurrentUser.Name + ", " + UserController.CurrentUser.Age,
                    TextColor = ColorController.CurrentTheme.FontColor,
                    TextDecorations = TextDecorations.Underline,
                    FontSize = 22
                };
                userInfo.Children.Add(nameAgeLabel);

                var genderLabel = new Label()
                {
                    Text = "Gender: " + UserController.CurrentUser.Gender.Title,
                    TextColor = ColorController.CurrentTheme.FontColor,
                    FontSize = 16
                };
                userInfo.Children.Add(genderLabel);

                var statusLabel = new Label()
                {
                    Text = "Status: Active",
                    TextColor = ColorController.CurrentTheme.FontColor,
                    FontSize = 16
                };
                userInfo.Children.Add(statusLabel);

                var repLabel = new Label()
                {
                    Text = "Reciprocity: Accepted",
                    TextColor = ColorController.CurrentTheme.FontColor,
                    FontSize = 16
                };
                userInfo.Children.Add(repLabel);

                var hSize = 0.2f * frameStack.Width;
                var wSize = 0.3f * frameStack.Width;

                var userPhoto = new Image();
                //userPhoto.Source = ImageSource.FromResource("XamarinApp.Images.UserIconM.png");
                userPhoto.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new Uri("https://zachiska.com/wp-content/uploads/2020/07/e-girl-hairstyle.jpg")
                };
                userPhoto.Aspect = Aspect.AspectFill;

                var userFrame = new Frame
                {
                    BorderColor = ColorController.CurrentTheme.AddColor,
                    Content = userPhoto,
                    BackgroundColor = ColorController.CurrentTheme.BackColor,
                    WidthRequest = wSize,
                    HeightRequest = hSize,
                    Padding = new Thickness(1,1,1,1)
                };

                grid.Children.Add(userFrame, 0, 0);
                grid.Children.Add(userInfo, 1, 0 );

                frame.Content = grid;

                SwipeItem item = new SwipeItem
                {
                    Text = "Dislike",
                    BackgroundColor = ColorController.CurrentTheme.AddColor
                };
                item.Invoked += OnInvoked;
                SwipeItems swipeItems = new SwipeItems(new List<SwipeItem>() { item });
                swipeItems.Mode = SwipeMode.Execute;
                SwipeView swipeView = new SwipeView
                {
                    LeftItems = swipeItems,
                    RightItems = swipeItems,
                    Content = frame
                };

                frameStack.Children.Add(swipeView);
            }
            upStack.Children.Add(frameStack);
        }

        public void OnInvoked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Deleted", "OK");
        }
    }
}