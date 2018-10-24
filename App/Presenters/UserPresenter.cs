using System.Collections.Generic;
using App.Interfaces;
using App.Model;
using App.Service;

namespace App.Presenters
{
    internal class UserPresenter :IUserView
    {
        private List<UserModel> _userModel;
        private IUserService _userService;
        public  UserPresenter(IUserService userService,
                              List<UserModel> userModel)
        {
            _userService = userService;
            _userModel = userModel;

            populate();
        }

        public List<UserModel> UserList => _userModel;

        private void populate()
        {
            _userModel = _userService.GetAllUserList();
        }
    }
}