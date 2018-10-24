using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using App.Interfaces;
using App.Model;
using App.Presenters;

namespace App.Fragments
{
    public class UserFragment : Fragment, IUserView
    {
        private RecyclerView _recyclerView;
        private View _root;
        private UserListRecyclerAdapter adapter;
        private UserPresenter2 presenter;
        public List<UserModel> UserList => UserList;
        RecyclerView.LayoutManager mLayoutManager;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        { 
            _root = inflater.Inflate(Resource.Layout.fragment_container, container, false);
            _recyclerView = _root.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            presenter = new UserPresenter2(container);
            List<UserModel> UserListesi = presenter._userModel;

           // View recContainer = _root.FindViewById<ViewGroup>(Resource.Layout.UserItem);

            mLayoutManager = new LinearLayoutManager(_root.Context);
            _recyclerView.SetLayoutManager(mLayoutManager);

            adapter = new UserListRecyclerAdapter(this, UserListesi);
            _recyclerView.SetAdapter(adapter);

            return _root;
        }
        public class UserViewHolder : RecyclerView.ViewHolder
        {
            private readonly UserFragment _fragment;
            private readonly LinearLayout _userListLayout;

            public TextView Name { get; private set; }
            public TextView Surname { get; private set; }
            public TextView Description { get; private set; }

            public UserViewHolder(View itemView, UserFragment fragment) : base(itemView)
            {
                _fragment = fragment;
                //_userListLayout = itemView.FindViewById<LinearLayout>(Resource.Layout.UserItem);

               Name = itemView.FindViewById<TextView>(Resource.Id.UserNameTextView);
               Surname = itemView.FindViewById<TextView>(Resource.Id.UserSurNameTextView);
               Description = itemView.FindViewById<TextView>(Resource.Id.UserDescriptionTextView);
            }
            public void Bind (UserModel data)  
            {
                Name.Text =data.Name;
                Surname.Text = data.Surname;
                Description.Text = data.Description;
            }
        }
    }
    public class UserListRecyclerAdapter : RecyclerView.Adapter
    {
        private List<UserModel> _userList;
        private readonly UserFragment _fragment;

        public UserListRecyclerAdapter(UserFragment fragment, List<UserModel> UserList)
        {
            _userList = UserList;
            _fragment = fragment;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
          View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.UserItem, parent, false);
          UserFragment.UserViewHolder viewHolder = new UserFragment.UserViewHolder(itemView, _fragment);

          return viewHolder;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as UserFragment.UserViewHolder;
            holder.Name.Text = _userList[position].Name;
            holder.Surname.Text = _userList[position].Surname;
            holder.Description.Text = _userList[position].Description;
        }
        public override int ItemCount => _userList.Count;
    }
}