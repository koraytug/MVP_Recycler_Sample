using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using App.Fragments;
using System;
using App.Presenters;

namespace App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity 
    {
        private Button _btnLogin;
        private static string TAG = "MainActivity";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            _btnLogin = FindViewById<Button>(Resource.Id.btnRecyclerOpenerButtonView);
            //_btnLogin = (Button)FindViewById(Resource.Id.btnLoginButtonView);
            _btnLogin.Click += btnlogin_OnClick;
            UserFragment masterFragment = new UserFragment();

            FragmentManager.BeginTransaction().Add(Resource.Id.master_fragment_container, masterFragment, "").Commit();
        }
        
        private void btnlogin_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            switch (btn.Id)
            {
                case Resource.Id.btnRecyclerOpenerButtonView:
                    Log.Debug(TAG,msg:"onClick: kullanıcı diğer recycleri aç buttonuna bastı.");
                    
                    Intent intent = new Intent(this,typeof (RecyclerHolderActivity));
                    StartActivity(intent);
                    OverridePendingTransition(Android.Resource.Animation.FadeIn,Android.Resource.Animation.FadeOut);
                    break;
                default: 
                    break; 
            }
        }
    }
}