using System.Collections.Generic;
using Android.Views;
using App.Interfaces;
using App.Model;
using App.Service;

namespace App.Presenters
{
    public class UserPresenter2 
    {
        public List<UserModel> _userModel;
        private View view;
        private IUserService _userService;
        public  UserPresenter2(View view)
        {
            _userService = new UserService(new Repositories.UserRepository()); 
            this.view = view;

            populate();
        } 

        private void populate()
        {
            _userModel = _userService.GetAllUserList();
        }
    }
}