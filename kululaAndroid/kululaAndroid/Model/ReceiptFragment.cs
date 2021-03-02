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
    public class ReceiptFragment : Fragment
    {
        private KululaUrl url = new KululaUrl();
        Context Context;
        private TextView txt_receiptA, txt_receiptA2, txt_receiptB, txt_receiptB2, txt_receiptC;
        private TextView txt_receiptC2, txt_receiptD, txt_receiptD2, txt_receiptE, txt_receiptE2,txtDateStamp;
        public  override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.receipt_fragment, container, false);
            Context = view.Context;
            txt_receiptA = view.FindViewById<TextView>(Resource.Id.txt_receiptA);
            txt_receiptA2 = view.FindViewById<TextView>(Resource.Id.txt_receiptA2);
            txt_receiptB = view.FindViewById<TextView>(Resource.Id.txt_receiptB);
            txt_receiptB2 = view.FindViewById<TextView>(Resource.Id.txt_receiptB2);
            txt_receiptC = view.FindViewById<TextView>(Resource.Id.txt_receiptC);
            txt_receiptC2 = view.FindViewById<TextView>(Resource.Id.txt_receiptC2);
            txt_receiptD = view.FindViewById<TextView>(Resource.Id.txt_receiptD);
            txt_receiptD2 = view.FindViewById<TextView>(Resource.Id.txt_receiptD2);
            txt_receiptE = view.FindViewById<TextView>(Resource.Id.txt_receiptE);
            txt_receiptE2 = view.FindViewById<TextView>(Resource.Id.txt_receiptE2);
            txtDateStamp = view.FindViewById<TextView>(Resource.Id.txt_receiptDate);

            Intent intent = new Intent();
            if (intent.GetBooleanExtra("IsFlightPayment", false))
            {
                FlightReceiptPost();
                SeatReceiptPost();
            }
            else
            {
                CarReceiptPost();
            }
            Carhire c = new Carhire();
            c.CarName = "Toyota";
            c.DropOff = "Sandton";
            c.pickUp = "Alex";
            c.IsReturn = true;
            c.memberIDC = "Sakie";
            c.PickDate = DateTime.Now;

            SetData(c);
            return view;
        }
       
        private async void CarReceiptPost()
        {
          /*  HttpClient client = new HttpClient();
            var uri = new Uri(url.rootUrl + url.UrlCarReceiptGet);
            var data = await client.GetAsync(uri);
            var jsonData = await data.Content.ReadAsStringAsync();

            try
            {
               var ReceiptData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Carhire>>(jsonData);
            }
            catch (Exception ex) { Toast.MakeText(Context,"Server error " +ex.Message, ToastLength.Long).Show(); }*/
        }
        private async void FlightReceiptPost()
        {
           /* HttpClient client = new HttpClient();
            var uri = new Uri(url.rootUrl + url.UrlFlightReceiptGet);
            var data = await client.GetAsync(uri);
            var jsonData = await data.Content.ReadAsStringAsync();

            try
            {
                var ReceiptData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FlightBooks>>(jsonData);
            }
            catch (Exception ex) { Toast.MakeText(Context, "Server error " + ex.Message, ToastLength.Long).Show(); }*/
        }
        private async void SeatReceiptPost()
        {
          /*  HttpClient client = new HttpClient();
            var uri = new Uri(url.rootUrl + url.UrlSeatbookReceiptGet);
            var data = await client.GetAsync(uri);
            var jsonData = await data.Content.ReadAsStringAsync();

            try
            {
                var ReceiptData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FlightBooks>>(jsonData);

                SetData(ReceiptData);
            }
            catch (Exception ex) { Toast.MakeText(Context, "Server error " + ex.Message, ToastLength.Long).Show(); }*/
        }
        private void SetData(object obj)
        {
           if(obj.GetType()==typeof(Carhire))
            {

                var carhire =(Carhire)obj;
                txt_receiptA.Text = "Pick Up @ ";
                txt_receiptA2.Text = carhire.pickUp;

                txt_receiptB.Text = "Drop Off @ ";
                txt_receiptB2.Text = carhire.DropOff;

                txt_receiptC.Text = "Date of Pick up :";
                txt_receiptC2.Text = carhire.PickDate.ToString();

                txt_receiptD.Text = "Hired Car :";
                txt_receiptD2.Text = carhire.CarName;

                txt_receiptE.Text = "Is Return Booked :";
                txt_receiptE2.Text = carhire.IsReturn.ToString();

                txtDateStamp.Text = DateTime.Now.ToLongDateString()+" @"+ DateTime.Now.ToLongTimeString();
         
            }
        }
    }
}