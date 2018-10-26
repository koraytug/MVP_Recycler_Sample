using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using App.Fragments;
using App.Model;

namespace App.Adapters
{
    public class RecyclerViewAdapter: RecyclerView.Adapter
    {
        private List<UserModel> _userList;
        private readonly Context _context;
        
        public RecyclerViewAdapter(Context context, List<UserModel> UserList)
        {
            _userList = UserList;
            _context = context;
        }
        
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.layout_main_feed, parent, false);
          RecyclerView.ViewHolder viewHolder = new RecyclerView.ViewHolder(view);

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