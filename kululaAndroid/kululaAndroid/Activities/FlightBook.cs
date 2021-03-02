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
using kululaAndroid.Model;
using Newtonsoft.Json;

namespace kululaAndroid.Activities
{
    [Activity(Label = "Flight")]
    public class FlightBook : Activity
    {
        private KululaUrl url = new KululaUrl();
        private EditText mEdtDestination, mEdtDepature, mEdtDepartDate, mEdtNumPeople, mEdtReturnDate;
        private RadioButton mRadio_return, mRadio_oneWay;
        private Button mBtnSearchF;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FlightBook);
            mEdtDepartDate = FindViewById<EditText>(Resource.Id.fSearch_Departure_D);
            mEdtDepature = FindViewById<EditText>(Resource.Id.fSearch_departure);
            mEdtDestination = FindViewById<EditText>(Resource.Id.fSearch_destination);
            mEdtReturnDate = FindViewById<EditText>(Resource.Id.fSearch_return_D);
            mEdtNumPeople = FindViewById<EditText>(Resource.Id.fSearch_NumPeople);
            mRadio_oneWay = FindViewById<RadioButton>(Resource.Id.fSearch_OneWay_radio);
            mRadio_return = FindViewById<RadioButton>(Resource.Id.fSearch_return_radio);
            mBtnSearchF = FindViewById<Button>(Resource.Id.btn_fSearch);

            mBtnSearchF.Click += MBtnSearchF_Click;
            mEdtDepartDate.Click += MEdtDepartDate_Click;
            mEdtReturnDate.Click += MEdtReturnDate_Click;
        }

        private void MEdtReturnDate_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {

                mEdtReturnDate.Text = time.Date.ToShortDateString();

            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
        private void MEdtDepartDate_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {

                mEdtDepartDate.Text = time.Date.ToShortDateString();

            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private async void MBtnSearchF_Click(object sender, EventArgs e)
        {

            if (mEdtDepature.Text == "") mEdtDepature.Error = "Depature Airport required";
            else if (mEdtDestination.Text == "") mEdtDestination.Error = "Destination Airport required";
            else if (mEdtNumPeople.Text == "") mEdtNumPeople.Error = "Number of people required";
            else
            {
                FlightBooks flightBook;
                flightBook = new FlightBooks
                {
                    DepartPlace = mEdtDepature.Text,
                    DestPlace = mEdtDestination.Text,
                    DepartDate = DateTime.Parse(mEdtDepartDate.Text),
                    returnDate = DateTime.Parse(mEdtReturnDate.Text),
                    NumPeople = int.Parse(mEdtNumPeople.Text),
                    IsReturn = mRadio_return.Selected
                };
                HttpClient client = new HttpClient();

                var uri = new Uri(url.rootUrl + url.UrlFlightbookPost);
                var data = JsonConvert.SerializeObject(flightBook);
                var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponse = await client.PostAsync(uri, httpContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //  Intent intent=new Intent(Resource.Layout.  )
                    //Toast.MakeText(this, "", ToastLength.Long).Show();
                }
                else Toast.MakeText(this, "", ToastLength.Long).Show();
                // var json = await result.Content.ReadAsStringAsync();
            }
        }
        }
}