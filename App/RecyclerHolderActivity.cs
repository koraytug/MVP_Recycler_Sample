using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using App.Fragments;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

namespace App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class RecyclerHolderActivity: AppCompatActivity
    {
        private static string TAG = "RecyclerHolderActivity";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RecyclerHolderLayout);
            Log.Debug(TAG,msg:"onCreate: Başlatıldı.");
            Init();

        }

        private void Init()
        {
            RecyclerHomeFragment recyclerFragment = new RecyclerHomeFragment();
            FragmentTransaction transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.RecyclerContentFrame, recyclerFragment,
                GetString((Resource.String.tag_recycler_fragment_home)));
            transaction.AddToBackStack(GetString(Resource.String.tag_recycler_fragment_home));
            transaction.Commit();

        }
    }
}