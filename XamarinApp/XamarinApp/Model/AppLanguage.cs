using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Model
{
    public class AppLanguage
    {
        public string Title { get; private set; }
        public string CI { get; private set; }

        public AppLanguage(string title, string ci)
        {
            Title = title;
            CI = ci;
        }
    }
}
