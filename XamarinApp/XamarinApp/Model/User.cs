using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Model
{
    public class User
    {
        public int Id;
        public string Login;
        public string Password;

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }

        public byte Age { get; private set; }
        public UserPosition UserPosition { get; private set; }
        public DateTime lastTimeVisited { get; private set; }

        public List<int> LikedId { get; private set; }
        public UserData UserPhoto { get; private set; }
    }
}
