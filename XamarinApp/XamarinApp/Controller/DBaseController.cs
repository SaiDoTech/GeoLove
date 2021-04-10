using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinApp.Model;

namespace XamarinApp.Controller
{
    public class DBaseController
    {
        public static FirebaseClient firebaseClient { get; private set; }

        public DBaseController(string key)
        {
            firebaseClient = new FirebaseClient(key);
        }

        public static async Task<User> CheckUser(string userName, string pass)
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child("Users")
                    .OnceAsync<User>()).Where(a => a.Object.Login == userName).Where(b => b.Object.Password == pass).FirstOrDefault();

                if (gotted != null)
                {
                    var content = gotted.Object as User;
                    return content;
                }
            }
            return null;
        }

        public static async Task<List<User>> GetUsers()
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child("Users")
                    .OnceAsync<User>()).Select(user => new User
                    {
                        Login = user.Object.Login,
                        Id = user.Object.Id
                    }).ToList(); 

                if (gotted != null)
                {
                    return new List<User>(gotted);
                }
            }
            return null;
        }
    }
}
