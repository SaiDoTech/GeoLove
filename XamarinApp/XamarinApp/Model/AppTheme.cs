using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinApp.Model
{
    public class AppTheme
    {
        public string Title { get; private set; }
        public Color BackColor { get; private set; }
        public Color AddColor { get; private set; }
        public Color FontColor { get; private set; }

        public AppTheme(string title, Color back, Color add, Color font)
        {
            Title = title;
            BackColor = back;
            AddColor = add;
            FontColor = font;
        }
    }
}
