using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.Model;

namespace App.Repositories
{
    public class UserRepository
    {
        public   List<UserModel> GetAllUsers()
        {
            List < UserModel > users = new List<UserModel>()
            {
                new UserModel()
                {
                    UserId = 1,
                    Name= "Koray",
                    Surname = "TUĞ",
                    Description = "VirtuDev"
                },
                new UserModel()
                {
                    UserId = 1,
                    Name= "Ali",
                    Surname = "TUĞ",
                    Description = "VirtuDev"
                },
                new UserModel()
                {
                    UserId = 1,
                    Name= "Caner",
                    Surname = "BEKTAS",
                    Description = "VirtuDev"
                },
                new UserModel()
                {
                    UserId = 1,
                    Name= "Serdar",
                    Surname = "AKIS",
                    Description = "VirtuDev"
                },
                new UserModel()
                {
                    UserId = 1,
                    Name= "Samet",
                    Surname = "CELIKBIÇAK",
                    Description = "VirtuDev"
                },
                new UserModel()
                {
                    UserId = 1,
                    Name= "Arif",
                    Surname = "KURSAD KAVAS",
                    Description = "VirtuDev"
                },
                new UserModel()
                {
                    UserId = 1,
                    Name = "Burak",
                    Surname = "TOZKOPARAN",
                    Description = "VirtuDev"
                },
                new UserModel()
                {
                    UserId = 1,
                    Name = "Martin",
                    Surname = "AXABRINK",
                    Description = "VirtuDev"
                },
                new UserModel()
                {
                    UserId = 1,
                    Name = "Daniel",
                    Surname = "SALOMONSSON",
                    Description = "VirtuDev"
                }
            };
            return users;
        }

        public  UserModel GetUserdById(int UserId)
        {
            List<UserModel> Users = GetAllUsers();
            var user = Users.Where(h => h.UserId == UserId).FirstOrDefault();

            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}