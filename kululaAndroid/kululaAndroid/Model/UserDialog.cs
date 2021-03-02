using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using kululaAndroid.Activities;
using Newtonsoft.Json;

namespace kululaAndroid.Model
{
   
    class RegisterDialog : DialogFragment
    {
        private EditText mtxtConfirmPassword;
        private EditText mtxtEmail;
        private EditText mtxtPassword;
        private Button mBtnSignUp;
        private TextView mTxtError;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Drawable.DialogRegistration, container, false);

            mtxtEmail = view.FindViewById<EditText>(Resource.Id.signup_input_email);
            mtxtConfirmPassword = view.FindViewById<EditText>(Resource.Id.signup_input_ConfirmPassword);
            mtxtPassword = view.FindViewById<EditText>(Resource.Id.signup_input_password);
            mBtnSignUp = view.FindViewById<Button>(Resource.Id.btn_signup);
            mTxtError= view.FindViewById<TextView>(Resource.Id.signup_txtError);

            mBtnSignUp.Click += MBtnSignUp_Click;
            return view;
        }
        private FragmentTransaction transaction;
        private Register register;
        private async void MBtnSignUp_Click(object sender, EventArgs e)
        {
            if (mtxtEmail.Text == "") mtxtEmail.Error = "Email address required";    
            else if (mtxtPassword.Text == "") mtxtPassword.Error = "Password required";
            if (mtxtPassword.Text == mtxtConfirmPassword.Text)
            {
                register = new Register(mtxtEmail.Text, mtxtPassword.Text,mtxtPassword.Text);

                //Account activation api to implement

                HttpClient client = new HttpClient();
                KululaUrl url = new KululaUrl();
         

                var uri = new Uri(url.rootUrl+url.UrlRegisterPost);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                var json = JsonConvert.SerializeObject(register);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response =  await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    transaction = FragmentManager.BeginTransaction();
                    AccActivation userDetailsDialog = new AccActivation();
                    userDetailsDialog.SetStyle(DialogFragmentStyle.NoTitle, 0);
                    userDetailsDialog.Show(transaction, "Account Activation");
                   
                    Clear();
                    Dismiss();
                }
                else mTxtError.Text = "Server error! "+response.StatusCode;
            }
            else  mtxtConfirmPassword.Error = "Confirm password do not match password";
                
        }
        private void Clear()
        {
            mtxtEmail.Text = "";
            mtxtPassword.Text = "";
            mtxtConfirmPassword.Text = "";
        }
    }
    //User details dialog class
    class UserDetailsDialog : DialogFragment
    {
        private Button mBtnSignupDetails;
        private EditText mTxtFname, mTxtLname, mTxtPhone, mTxtAddress,mTxtId;
        private RadioButton mRadio_male, mRadio_female;
        View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Drawable.DialogUserDetails, container, false);
            mBtnSignupDetails = view.FindViewById<Button>(Resource.Id.btn_signupDetails);
            mTxtFname = view.FindViewById<EditText>(Resource.Id.signup_input_Fname);
            mTxtLname = view.FindViewById<EditText>(Resource.Id.signup_input_Lname);
            mTxtPhone = view.FindViewById<EditText>(Resource.Id.signup_input_phone);
            mTxtAddress= view.FindViewById<EditText>(Resource.Id.signup_input_address);
            mTxtId = view.FindViewById<EditText>(Resource.Id.signup_input_ID);
            mRadio_male = view.FindViewById<RadioButton>(Resource.Id.male_radio_btn);
            mRadio_female = view.FindViewById<RadioButton>(Resource.Id.female_radio_btn);

            mBtnSignupDetails.Click += MBtnSignupDetails_Click;
            return view;
        }
        
        private async void MBtnSignupDetails_Click(object sender, EventArgs e)
        {
            if (mTxtPhone.Text == null) mTxtPhone.Error = "Phone number required";
            else if (mTxtAddress.Text == null) mTxtAddress.Error = "Physical address required";
            else if (mTxtFname.Text == null) mTxtFname.Error = "First name required";
            else if (mTxtLname.Text == null) mTxtLname.Error = "Last name required";
            else if (mTxtId.Text == null) mTxtId.Error = "Identity number required";

            Client userDetails = new Client {
                Address = mTxtAddress.Text,
                FirstName=mTxtFname.Text,
                LastName=mTxtLname.Text,
                IdNumber=mTxtId.Text,
                PhoneNo=mTxtPhone.Text,

            };
            if (mRadio_male.Selected == true) userDetails.Gender = "Male";
            else userDetails.Gender = "Female";

            HttpClient client = new HttpClient();
            KululaUrl url = new KululaUrl();
          
            var uri = new Uri(url.rootUrl+url.UrlClientDetailsPost);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(userDetails);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await client.PostAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //StartActivity(typeof(User));
                var activity2 = new Intent(this.Activity, typeof(User));
                activity2.PutExtra("FirstName", mTxtFname.Text);
                StartActivity(activity2);
                InputClear();
            }
            else mTxtAddress.Text = "Server error! "+response.StatusCode;
        }
        private void InputClear()
        {
            mTxtAddress.Text = "";
            mTxtFname.Text = "";
            mTxtId.Text = "";
            mTxtLname.Text = "";
            mTxtPhone.Text = "";
        }
    }
    //Account activation dialog class
    class AccActivation : DialogFragment
    {
        private Button mBtnActivation;
        private EditText mTxtActivation;
        private TextView mTxtV_activation;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Drawable.DialogAccActivation, container, false);
            mBtnActivation = view.FindViewById<Button>(Resource.Id.btnActivation);
            mTxtActivation = view.FindViewById<EditText>(Resource.Id.txtActivationCode);
            mTxtV_activation = view.FindViewById<TextView>(Resource.Id.textV_accActivation);



            mBtnActivation.Click += MBtnActivation_Click;
            return view;
        }

        private FragmentTransaction transaction;
        private void MBtnActivation_Click(object sender, EventArgs e)
        {
            transaction = FragmentManager.BeginTransaction();
            UserDetailsDialog userDetailsDialog = new UserDetailsDialog();
            userDetailsDialog.Show(transaction, "User Details");
        }
    }
}