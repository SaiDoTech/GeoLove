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

        public static async Task<User> LogInUser(string login, string pass)
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child("Users")
                    .OnceAsync<User>()).Where(a => a.Object.Login == login).Where(b => b.Object.Password == pass).FirstOrDefault();

                if (gotted != null)
                {
                    User user = new User(gotted.Object.Id, gotted.Object.Login, gotted.Object.Password, gotted.Object.Name,gotted.Object.DateOfBirth, gotted.Object.Gender);
                    return user;
                }
            }
            return null;
        }

        public static async Task<int> GetUsersCount()
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child("Users")
                    .OnceAsync<User>()).Count;
                return gotted;
            }
            return 0;
        }

        public static async Task<bool> RegUser(User user)
        {
            if ((user != null) && (firebaseClient != null))
            {
                await firebaseClient
                    .Child("Users")
                    .PostAsync(user);

                return true;
            }
            else
                return false;
        }

        public static async Task<List<User>> GetAllUsers()
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child("Users")
                    .OnceAsync<User>()).Select(user => new User
                    {
                        Id = user.Object.Id,
                        Login = user.Object.Login,
                        Password = user.Object.Password,
                        Name = user.Object.Name,
                        DateOfBirth = user.Object.DateOfBirth,
                        Gender = user.Object.Gender
                    }).ToList();

                if (gotted != null)
                {
                    return new List<User>(gotted);
                }
            }
            return null;
        }

        public static async Task<bool> IsLoginFree(string login)
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child("Users")
                    .OnceAsync<User>()).Where(a => a.Object.Login == login).FirstOrDefault();

                if (gotted != null)
                    return false;
            }
            return true;
        }

        public static async Task<bool> UpdateUser(User user)
        {
            if ((user != null) && (firebaseClient != null))
            {
                var deleted = (await firebaseClient
                    .Child("Users")
                    .OnceAsync<User>()).Where(a => a.Object.Login == user.Login).FirstOrDefault();
                await firebaseClient.Child("Users").Child(deleted.Key).DeleteAsync();

                if (deleted.Object != null)
                {
                    await firebaseClient.Child("Users").PostAsync(user);

                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
                return false;
        }
    }
}
