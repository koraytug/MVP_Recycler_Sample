using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Util;

namespace App.Fragments
{
    public class RecyclerHomeFragment: Android.Support.V4.App.Fragment 
    {
        private static string TAG = "RecyclerHomeFragment";
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_recycler_home, container, false);
            Log.Debug(TAG,msg:"OnCreateView: Başlatıldı.");
            return view;
        }
        
    }
}