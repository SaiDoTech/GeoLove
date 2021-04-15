﻿using System;
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
        }
    
        protected override void OnAppearing()
        {
            ReColor();

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
                        new ColumnDefinition{ Width = new GridLength(0.5f, GridUnitType.Star ) },
                        new ColumnDefinition{ Width = new GridLength(0.25f, GridUnitType.Star ) },
                    }
                };

                var userInfo = new StackLayout();
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
                    Text = "Reciprocity: True",
                    TextColor = ColorController.CurrentTheme.FontColor,
                    FontSize = 16
                };
                userInfo.Children.Add(repLabel);

                var hSize = 0.15f * frameStack.Width;
                var wSize = 0.25f * frameStack.Width;

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

                var unlikePhoto = new Image
                {
                    Source = ImageSource.FromResource("XamarinApp.Images.UnlikeIcon.png"),
                    WidthRequest = wSize,
                    HeightRequest = hSize,
                    Aspect = Aspect.AspectFill
                };

                var unlikeFrame = new Frame
                {
                    BorderColor = ColorController.CurrentTheme.AddColor,
                    Content = unlikePhoto,
                    BackgroundColor = ColorController.CurrentTheme.BackColor,
                    Padding = new Thickness(1, 1, 1, 1)
                };

                grid.Children.Add(userFrame, 0, 0);
                grid.Children.Add(userInfo, 1, 0 );
                grid.Children.Add(unlikeFrame, 2, 0);

                frame.Content = grid;
                frameStack.Children.Add(frame);
            }
        }
    }
}