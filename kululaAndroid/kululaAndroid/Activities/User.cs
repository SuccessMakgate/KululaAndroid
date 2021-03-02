using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using kululaAndroid.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace kululaAndroid.Activities
{
    [Activity(Label = "User")]
    public class User : Activity
    {
        private Button mBtnSignIn;
        private Button mBtnNotRegistered;
        private EditText mEmailTxt;
        private EditText mPasswordTxt;
        private ProgressBar mProgressBar;
        private TextView mtxtAccount;

        protected override void OnStart()
        {
            base.OnStart();
            Thread thread = new Thread(WelcomeTheread);
            thread.Start();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.User);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.signin_progressBar);
            mBtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            mEmailTxt = FindViewById<EditText>(Resource.Id.signin_input_email);
            mPasswordTxt = FindViewById<EditText>(Resource.Id.signin_input_password);
            mBtnNotRegistered = FindViewById<Button>(Resource.Id.btn_notRegistered);
            mtxtAccount = FindViewById<TextView>(Resource.Id.txtCreateAccount);

            mBtnSignIn.Click += MBtnSignIn_Click;
            mBtnNotRegistered.Click += MBtnNotRegistered_Click;
        }
        private FragmentTransaction transaction;
        private void MBtnNotRegistered_Click(object sender, EventArgs e)
        {
            transaction = FragmentManager.BeginTransaction();
            RegisterDialog registerDialog = new RegisterDialog();
            registerDialog.Show(transaction, "Registration");
        }
        private async void WelcomeTheread()
        {
            string Firstname = "";
            Firstname = this.Intent.GetStringExtra("FirstName");
            if (Firstname != "" && Firstname != null)
            {
                mtxtAccount.Text = string.Format("Hi " + Firstname + " Thank you for choosing us! ");
                mtxtAccount.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);

                mtxtAccount.SetShadowLayer(1, 0, 0, Color.Gold);

                Thread.Sleep(3000);
            }
            
            mtxtAccount.Text = "Welcome";
          // this.Intent.RemoveExtra("FirstName");
        }
        private void MBtnSignIn_Click(object sender, EventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeTheread);
            thread.Start();
        }
        private async void ActLikeTheread()
        {
            /*  HttpClient client = new HttpClient();
              KululaUrl url = new KululaUrl();

              var uri = new Uri(url.rootUrl+url.UrlLoginPost);

              var data = url.AuntheticationData(mEmailTxt.Text, mPasswordTxt.Text);

              client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-urlencoded"));
              HttpResponseMessage response;

              var content = new StringContent(data, Encoding.UTF8, "application/x-www-urlencoded");
              response = await client.PostAsync(uri, content);
              var token=await response.Content.ReadAsStringAsync();
              Token tokenJson = new Token();
              tokenJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Token>(token);
              if (response.StatusCode == System.Net.HttpStatusCode.OK)
              {
                  var activityMainMenu= new Intent(this, typeof(Navigation));
                  activityMainMenu.PutExtra("UserName", tokenJson.userName);
                  activityMainMenu.PutExtra("accessToken", tokenJson.access_token);
                  StartActivity(activityMainMenu);
              }
              else mEmailTxt.Error="Username does not exist!";*/
            var activityMainMenu = new Intent(this, typeof(Navigation));
            RunOnUiThread(() => { mProgressBar.Visibility = ViewStates.Invisible; });
            activityMainMenu.PutExtra("UserName", "Sakie.Test.com");
            activityMainMenu.PutExtra("accessToken", "1234");
            StartActivity(activityMainMenu);
        }
    }
    class Token
    {
        public string userName { get; set; }
        public string access_token { get; set; }
    }
}