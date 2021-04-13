using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.Model;

namespace XamarinApp.Controller
{
    class UserController
    {
        public static User CurrentUser { get; private set; }

        public UserController(User user)
        {
            if (user != null)
                CurrentUser = user;
        }
    }
}
