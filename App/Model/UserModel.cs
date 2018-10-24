using System;

namespace App.Model
{
    public class UserModel
    {
        //public UserModel(int userId, string name, string surname, string description)
        //{
        //    UserId = userId;
        //    Name = name;
        //    Surname = surname;
        //    Description = description;
        //}

        public int UserId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

    }
}