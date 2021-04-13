﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login{ get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public byte Age { get; set; }
        public UserPosition UserPosition { get; set; }
        public DateTime lastTimeVisited { get;  set; }

        public List<int> LikedId { get; set; }
        public UserData UserPhoto { get; set; }

        public User(int id,
                    string login,
                    string pass,
                    string name,
                    DateTime dob,
                    Gender gender)
        {
            if (id > 0)
                this.Id = id;
            else
                throw new Exception("Wrong user's ID");

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrWhiteSpace(login))
                this.Login = login;
            else
                throw new Exception("Please, enter your login!");

            if (!string.IsNullOrWhiteSpace(pass) && !string.IsNullOrWhiteSpace(pass))
                this.Password = pass;
            else
                throw new Exception("Please, enter your password!");

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(name))
                this.Name = name;
            else
                throw new Exception("Please, enter your name!");

            if (dob != null)
                this.DateOfBirth = dob;
            else
                throw new Exception("Please, set your date of Birth!");

            if (gender != null)
                this.Gender = gender;
            else
                throw new Exception("Please, set your gender!");
        }

        public User()
        {

        }
    }
}
