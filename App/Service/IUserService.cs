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
using App.Repositories;

namespace App.Service
{
    internal interface IUserService
    {
        List<UserModel> GetAllUserList();
    }

    internal class UserService : IUserService
    {
        private UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserModel> GetAllUserList()
        {
           return _userRepository.GetAllUsers();
        }
    }
}