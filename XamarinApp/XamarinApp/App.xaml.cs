﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Pages;

namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LogInPage();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
