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
          //Setup and inflate your layout here
          // var id = Resource.Layout.fragment_container;

          var id = Resource.Layout.UserItem;

          //var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

          View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.UserItem, parent, false);
          UserFragment.UserViewHolder viewHolder = new UserFragment.UserViewHolder(itemView, _fragment);

          return viewHolder;
           // return new UserFragment.UserViewHolder(itemView, _fragment);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            //var item = images[position];
            //// Replace the contents of the view with that element
            //var holder = viewHolder as ImageAdapterViewHolder;
            //holder.Caption.Text = item.Title;
            //Picasso.With(activity).Load(item.ImageLink).Into(holder.Image);

            var holder = viewHolder as UserFragment.UserViewHolder;
            holder.Name.Text = _userList[position].Name;
            holder.Surname.Text = _userList[position].Surname;
            holder.Description.Text = _userList[position].Description;

            //Picasso.With(activity).Load(item.ImageLink).Into(holder.Image);
        }
        public override int ItemCount => _userList.Count;
    }
    ////----------------------------------------------------------------------
    //// ADAPTER

    //// Adapter to connect the data set (photo album) to the RecyclerView: 
    //public class UserListRecyclerAdapter : RecyclerView.Adapter
    //{
    //    // Event handler for item clicks:
    //    public event EventHandler<int> ItemClick;

    //    // Underlying data set (a photo album):
    //    public UserModel _mUser;

    //    // Load the adapter with the data set (photo album) at construction time:
    //    public UserListRecyclerAdapter(UserModel user)
    //    {
    //        _mUser = user;
    //    }

    //    // Create a new photo CardView (invoked by the layout manager): 
    //    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    //    {
    //        var id = Resource.Layout.item;
    //        // Inflate the CardView for the photo:
    //        View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Id.recyclerView, parent, false);

    //        // Create a ViewHolder to find and hold these view references, and 
    //        // register OnClick with the view holder:
    //        App.Fragments.UserFragment.UserViewHolder vh = new App.Fragments.UserFragment.UserViewHolder(parent.recy_recycelerView, OnClick);
    //        return vh;
    //    }

    //    // Fill in the contents of the photo card (invoked by the layout manager):
    //    public override void
    //        OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    //    {
    //        PhotoViewHolder vh = holder as PhotoViewHolder;

    //        // Set the ImageView and TextView in this ViewHolder's CardView 
    //        // from this position in the photo album:
    //        vh.Image.SetImageResource(mPhotoAlbum[position].PhotoID);
    //        vh.Caption.Text = mPhotoAlbum[position].Caption;
    //    }

    //    // Return the number of photos available in the photo album:
    //    public override int ItemCount
    //    {
    //        get { return mPhotoAlbum.NumPhotos; }
    //    }

    //    // Raise an event when the item-click takes place:
    //    void OnClick(int position)
    //    {
    //        if (ItemClick != null)
    //            ItemClick(this, position);
    //    }
    //}
}