using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace kululaAndroid.Activities
{
    [Activity(Label = "ContentMenu")]
    public class ContentMenu : Activity
    {
        ImageButton main_btn_dash, main_btn_carhire, main_btn_flightBook,main_btn_logout;
        TextView mTxtViewSignout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            main_btn_carhire = FindViewById<ImageButton>(Resource.Id.main_btn_carHire);
            main_btn_dash = FindViewById<ImageButton>(Resource.Id.main_btn_dash);
            main_btn_flightBook = FindViewById<ImageButton>(Resource.Id.main_btn_flightBook);
            main_btn_logout = FindViewById<ImageButton>(Resource.Id.main_btn_Logout);
            mTxtViewSignout = FindViewById<TextView>(Resource.Id.textSignout);

            main_btn_logout.Click += Main_btn_logout_Click;
            main_btn_carhire.Click += delegate { StartActivity((typeof(CarHire))); };
            main_btn_dash.Click += delegate { StartActivity((typeof(Dashboard))); };
            main_btn_flightBook.Click += delegate { StartActivity((typeof(FlightBook))); };
            mTxtViewSignout.Text = "Reverside@mail.com";
        }

        private void Main_btn_logout_Click(object sender, EventArgs e)
        {
            //Remove tokens 
            StartActivity(typeof(User));
        }
    }
}