using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using kululaAndroid.Model;

namespace kululaAndroid.Activities
{
    [Activity(Label = "Dashboard")]
    public class Dashboard : Activity
    {
        private LayoutInflater inflater;
        private LinearLayout mDashLayout;
        private Button mBtnDiscount, mBtnChangePass, mBtnFlightBook_h, mBtnCarhire_h, mBtnUpdatePro;
        private Button mBtnChangepassForm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Dashboard);
            mBtnCarhire_h = FindViewById<Button>(Resource.Id.btnCarHire_H);
            mBtnChangePass = FindViewById<Button>(Resource.Id.btnChangePassword);
            mBtnDiscount = FindViewById<Button>(Resource.Id.btnDiscount_H);
            mBtnFlightBook_h = FindViewById<Button>(Resource.Id.btnFlightBook_H);
            mBtnUpdatePro = FindViewById<Button>(Resource.Id.UpdateProfile);
            mBtnChangepassForm = FindViewById<Button>(Resource.Id.dash_btn_changePass);

            inflater= LayoutInflater.From(this);
            mDashLayout = this.Window.FindViewById<LinearLayout>(Resource.Id.dashLayout);

            mBtnCarhire_h.Click += MBtnCarhire_h_Click;
            mBtnChangePass.Click += MBtnChangePass_Click;
            mBtnDiscount.Click += MBtnDiscount_Click;
            mBtnFlightBook_h.Click += MBtnFlightBook_h_Click;
            mBtnUpdatePro.Click += MBtnUpdatePro_Click;

    
        }

        private void MBtnUpdatePro_Click(object sender, EventArgs e)
        {
            Btn_Activater();
            mDashLayout.RemoveAllViews();
            mBtnUpdatePro.Clickable = false;
            mBtnUpdatePro.SetBackgroundColor(Color.ParseColor("#ff20bf22"));
          //  ListViewAdapter
            View inflatedLayout = inflater.Inflate(Resource.Menu.UpdateProfile, null);
            
            mDashLayout.AddView(inflatedLayout);
        }

        private void MBtnFlightBook_h_Click(object sender, EventArgs e)
        {
            Btn_Activater();
            mBtnFlightBook_h.Clickable = false;
            mBtnFlightBook_h.SetBackgroundColor(Color.ParseColor("#ff20bf22"));
            mDashLayout.RemoveAllViews();
            View inflatedLayout = inflater.Inflate(Resource.Drawable.DialogUserDetails, null);
            mDashLayout.AddView(inflatedLayout);
            StartActivity(typeof(ListViewActivity));
        }

        private void MBtnDiscount_Click(object sender, EventArgs e)
        {
            Btn_Activater();
            mDashLayout.RemoveAllViews();
            mBtnDiscount.Clickable = false;
            mBtnDiscount.SetBackgroundColor(Color.ParseColor("#ff20bf22"));
            //View inflatedLayout = inflater.Inflate(Resource.Drawable.DialogUserDetails, null);
            //mDashLayout.AddView(inflatedLayout);
            CarhireFragment carhireFragment = new CarhireFragment();
            FragmentTransaction transaction = FragmentManager.BeginTransaction().Replace(Resource.Id.dashLayout, carhireFragment);
            transaction.Commit();

        }

        private void MBtnChangePass_Click(object sender, EventArgs e)
        {
            Btn_Activater();
            mDashLayout.RemoveAllViews();
            mBtnChangePass.Clickable = false;
            mBtnChangePass.SetBackgroundColor(Color.ParseColor("#ff20bf22"));
            View inflatedLayout = inflater.Inflate(Resource.Menu.ChangePasswordForm, null);
            mDashLayout.AddView(inflatedLayout);        
        }

        private void MBtnChangepassForm_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Button clcikcs", ToastLength.Long);
        }

        private void MBtnCarhire_h_Click(object sender, EventArgs e)
        {
            Btn_Activater();
            mDashLayout.RemoveAllViews();
            mBtnCarhire_h.Clickable = false;
            mBtnCarhire_h.SetBackgroundColor(Color.ParseColor("#ff20bf22"));
            View inflatedLayout = inflater.Inflate(Resource.Drawable.DialogUserDetails, null);
            mDashLayout.AddView(inflatedLayout);     
        }
        private void Btn_Activater()
        {
            mBtnChangePass.Clickable = true;
            mBtnCarhire_h.Clickable = true;
            mBtnDiscount.Clickable = true;
            mBtnFlightBook_h.Clickable = true;
            mBtnUpdatePro.Clickable = true;
            mBtnChangePass.SetBackgroundColor(Color.ParseColor("#ffe0e0e0"));
            mBtnCarhire_h.SetBackgroundColor(Color.ParseColor("#ffe0e0e0"));
            mBtnDiscount.SetBackgroundColor(Color.ParseColor("#ffe0e0e0"));
            mBtnFlightBook_h.SetBackgroundColor(Color.ParseColor("#ffe0e0e0"));
            mBtnUpdatePro.SetBackgroundColor(Color.ParseColor("#ffe0e0e0"));
        }
    }
}