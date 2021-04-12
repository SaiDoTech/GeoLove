using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Model
{
    public class Gender
    {
        public string Title { get; private set; }

        public Gender(string title)
        {
            Title = title;
        }
    }
}
