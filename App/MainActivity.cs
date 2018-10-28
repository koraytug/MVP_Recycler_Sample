using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using App.Fragments;
using System;
using App.Presenters;
using Android.Support.Design.Widget;

namespace App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity 
    {
        private Button _btnLogin;
        private static string TAG = "MainActivity";
        private BottomNavigationView _bottomNavigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            _bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            _bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            
            UserFragment masterFragment = new UserFragment();

            FragmentManager.BeginTransaction().Add(Resource.Id.master_fragment_container, masterFragment, "").Commit();
        }

        private void initNavigationProperties()
        {
        }
        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            e.Item.SetChecked ( true);
            LoadFragment(e.Item.ItemId);
        }
        private void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = Fragment1.NewInstance();
                    break;
                case Resource.Id.menu_audio:
                    fragment = Fragment2.NewInstance();
                    break;
                case Resource.Id.menu_video:
                    fragment = Fragment3.NewInstance();
                    break;
            }

            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.master_fragment_container, fragment)
                .Commit();
        }
         
    }
}