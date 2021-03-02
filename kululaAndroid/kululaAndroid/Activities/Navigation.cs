using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using kululaAndroid.Model;

namespace kululaAndroid.Activities
{
    [Activity(Label = "Navigation")]
    public class Navigation : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        FragmentTransaction transaction;
        ImageButton main_btn_logout;
        TextView mTxtViewSignout;
        RelativeLayout ContentRender;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NavLayout);

            main_btn_logout = FindViewById<ImageButton>(Resource.Id.main_btn_Logout);
            mTxtViewSignout = FindViewById<TextView>(Resource.Id.textSignout);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            if(this.Intent.GetStringExtra("UserName") != "" || this.Intent.GetStringExtra("UserName")!=null) mTxtViewSignout.Text = this.Intent.GetStringExtra("UserName");
            else mTxtViewSignout.Text = "Invalid login";
            main_btn_logout.Click += Main_btn_logout_Click;

            FlightBookFragment flightBook = new FlightBookFragment();
            transaction = this.FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, flightBook);
            transaction.Commit();
        }
     
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_flight:
                    FlightBookFragment flightBook = new FlightBookFragment();
                    transaction = this.FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, flightBook);
                    transaction.Commit();
                    return true;
                case Resource.Id.navigation_dashboard:
                    DashboardFragment dashboard = new DashboardFragment();
                    transaction = this.FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, dashboard);
                    transaction.Commit();
                    return true;
                case Resource.Id.navigation_car:
                    CarhireFragment carhire = new CarhireFragment();
                    transaction = this.FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, carhire);
                    transaction.Commit();
                    return true;
            }
            return false;
        }
        private void Main_btn_logout_Click(object sender, EventArgs e)
        {
            //Remove tokens 
            StartActivity(typeof(User));
        }
    }
}