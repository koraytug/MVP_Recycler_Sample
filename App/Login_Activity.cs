using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App
{ 
    [Activity(Label = "Login_Activity", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Login_Activity : Activity
    {
        private Button _btnLogin;
        private static string TAG = "Login_Activity";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_layout);

            _btnLogin = FindViewById<Button>(Resource.Id.loginButtonView); 
            _btnLogin.Click += btnlogin_OnClick; 
        }

        private void btnlogin_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            switch (btn.Id)
            {
                case Resource.Id.loginButtonView:
                    Log.Debug(TAG,msg:"onClick: kullanıcı login buttonuna bastı.");

                    Intent intent = new Intent(this,typeof (MainActivity));
                    StartActivity(intent);
                    OverridePendingTransition(Android.Resource.Animation.FadeIn,Android.Resource.Animation.FadeOut);
                    Finish();
                    break;
                default: 
                    break; 
           }
       }
    }
}