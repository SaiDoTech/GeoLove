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
    public partial class TablePage : ContentPage
    {
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

           // foreach (var item in temp)
           // {
           //     var lol = new Label
           //     {
           //         Text = item.Login
           //     };
           //    TableStack.Children.Add(lol);
           // }
        }
    
        protected override void OnAppearing()
        {
            ReColor();

            // CLEAR STACK!!!
            frameStack.Children.Clear();
            ShowLikedUsers();
        }   

        private void ReColor()
        {
            this.BackgroundColor = ColorController.CurrentTheme.BackColor;
            upStack.BackgroundColor = ColorController.CurrentTheme.AddColor;
            sortPicker.TextColor = ColorController.CurrentTheme.BackColor;
        }

        private void ShowLikedUsers()
        {
            for (int i = 0; i < 10; i++)
            {
                var frame = new Frame();

                frame.Padding = new Thickness(5, 5, 5, 5);
                frame.BorderColor = ColorController.CurrentTheme.AddColor;
                frame.BackgroundColor = ColorController.CurrentTheme.BackColor;

                var grid = new Grid()
                {
                    RowDefinitions =
                    {
                        new RowDefinition()
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = new GridLength(0.25f, GridUnitType.Star ) },
                        new ColumnDefinition{ Width = new GridLength(0.5f, GridUnitType.Star ) },
                        new ColumnDefinition{ Width = new GridLength(0.25f, GridUnitType.Star ) },

                    }
                };

                var userInfo = new StackLayout();
                var nameAgeLabel = new Label()
                {
                    Text = UserController.CurrentUser.Name + ", " + UserController.CurrentUser.Age,
                    TextColor = ColorController.CurrentTheme.FontColor,
                    TextDecorations = TextDecorations.Underline
                };
                userInfo.Children.Add(nameAgeLabel);

                var userPhoto = new Image();
                userPhoto.Source = ImageSource.FromResource("XamarinApp.Images.UserIconM.png");

                grid.Children.Add(userPhoto, 0, 0);
                grid.Children.Add(userInfo, 1, 0 );
                grid.Children.Add(new BoxView { Color = Color.Green }, 2, 0);

                frame.Content = grid;
                frameStack.Children.Add(frame);
            }
        }
    }
}