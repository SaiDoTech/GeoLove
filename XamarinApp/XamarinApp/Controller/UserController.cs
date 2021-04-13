using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public static async Task<bool> CreateNewUser(string login, string pass, string name, DateTime dob, Gender gender)
        {
            var response = await DBaseController.IsLoginFree(login);

            if (response)
            {
                var id = await DBaseController.GetUsersCount();
                id++;

                var user = new Model.User(id, login, pass, name, dob, gender);

                var registered = await DBaseController.RegUser(user);
                if (registered)
                    return true;
                else
                    return false;
            }
            else
                throw new Exception("Sorry, but this login is already taken!");
        }
    }
}
