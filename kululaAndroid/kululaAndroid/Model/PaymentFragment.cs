using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace kululaAndroid.Model
{
    public class PaymentFragment : Fragment
    {
        Context thisContext;
        private EditText mEdtCvv, mEdtCardNO, mEdtCity, mEdtAddress, mEdtCardHolder;
        private Button mBtnPayment;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var view = inflater.Inflate(Resource.Menu.PaymentForm, container, false);

            thisContext = container.Context;
            mEdtAddress = view.FindViewById<EditText>(Resource.Id.payment_address);
            mEdtCardHolder = view.FindViewById<EditText>(Resource.Id.payment_cardHolder);
            mEdtCardNO = view.FindViewById<EditText>(Resource.Id.payment_cardNO);
            mEdtCity = view.FindViewById<EditText>(Resource.Id.payment_city);
            mEdtCvv = view.FindViewById<EditText>(Resource.Id.payment_cvv);
            mBtnPayment = view.FindViewById<Button>(Resource.Id.payment_btn);

            mBtnPayment.Click += MBtnPayment_Click;
            return view;
        }

        private async void MBtnPayment_Click(object sender, EventArgs e)
        {
            if (mEdtAddress.Text == "") mEdtAddress.Error = "Physical address required";
            else if (mEdtCardHolder.Text == "") mEdtCardHolder.Error = "Card Holder Name required";
            else if (mEdtCardNO.Text == "") mEdtCardNO.Error = "Card Number required";
            else if (mEdtCvv.Text == "") mEdtCvv.Error = "CVV Number required";
            else
            {
                Payment carhire;
                Intent intent = new Intent();
                bool IsFlightPayment= intent.GetBooleanExtra("IsFlightPayment", false);
                carhire = new Payment
                {
                    AccHolder = mEdtCardHolder.Text,
                    CardNo = mEdtCardNO.Text,  
                };
                if (IsFlightPayment) carhire.IsCarhire = false;
                else carhire.IsSeatBook = IsFlightPayment;
               /* HttpClient client = new HttpClient();
                KululaUrl url = new KululaUrl();

                var uri = new Uri(url.rootUrl + url.UrlPaymentPost);
                var data = JsonConvert.SerializeObject(carhire);
                var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponse = await client.PostAsync(uri, httpContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    FragmentTransaction transaction;
                    ReceiptFragment payment = new ReceiptFragment();
                    transaction = this.FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, payment);
                    transaction.Commit();
                }
                else Toast.MakeText(thisContext, "Server Errror " + httpResponse.StatusCode, ToastLength.Long).Show();*/

                FragmentTransaction transaction;
                ReceiptFragment payment = new ReceiptFragment();
                transaction = this.FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, payment);
                transaction.Commit();
            }
        }
    }
}