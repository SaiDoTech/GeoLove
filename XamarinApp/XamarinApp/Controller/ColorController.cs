using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApp.Model;
using XamarinApp.View;

namespace XamarinApp.Controller
{
    public class ColorController
    {
        public static AppTheme CurrentTheme { get; private set; }

        public static List<AppTheme> AppThemes { get; private set; }

        public ColorController()
        {
            var themeLight = new AppTheme("Light", Color.White, Color.FromHex("E6567A"), Color.FromHex("47C9AF"), Color.FromHex("3B3C3D"));
            var themeDark = new AppTheme("Dark", Color.FromHex("3B3C3D"), Color.FromHex("44B39D"), Color.FromHex("BF4A67"), Color.White);

            AppThemes = new List<AppTheme>()
            {
                themeLight,
                themeDark
            };

            CurrentTheme = AppThemes[0];
        }

        public static void ChangeTheme(int indx)
        {
            CurrentTheme = AppThemes[indx];
        }
    }
}
