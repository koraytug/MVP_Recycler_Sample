using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using App.Interfaces;
using App.Model;

namespace App.Fragments
{
    internal class UserListFragment : IUserView
    {
        private RecyclerView recyclerView;
        
        public List<UserModel> UserList => throw new NotImplementedException();

        public class UserListViewHolder : RecyclerView.ViewHolder
        {
            private readonly UserListFragment _fragment;
            private readonly LinearLayout _userListLayout;

            public TextView Name { get; private set; }
            public TextView Surname { get; private set; }
            public TextView Description { get; private set; }

            public UserListViewHolder(View itemView, UserListFragment fragment) : base(itemView)
            {
                _fragment = fragment;
                _userListLayout = itemView.FindViewById<LinearLayout>(0);
                //Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
                //Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            }
        }
    }
}