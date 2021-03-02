using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using kululaAndroid.Model;
using Newtonsoft.Json;

namespace kululaAndroid.Activities
{
    [Activity(Label = "CarHire")]
    public class CarHire : Activity
    {
        KululaUrl url = new KululaUrl();
        private Spinner mCarList_spinner;
        private ImageView mCarView;
        private EditText mEdtPickUp, mEdtDropOff, mEdtPickUp_D;
        private RadioButton mRadio_return, mRadio_oneWay;
        private Button mBtnCarHire;
        private string mCarName;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CarHire);

            mRadio_oneWay = FindViewById<RadioButton>(Resource.Id.cHire_oneWay_radio);
            mRadio_return = FindViewById<RadioButton>(Resource.Id.cHire_return_radio);
            mCarList_spinner = FindViewById<Spinner>(Resource.Id.cHire_carList_spinner);
            mCarView = FindViewById<ImageView>(Resource.Id.cHire_CarView);
            mEdtDropOff = FindViewById<EditText>(Resource.Id.cHire_dropOff);
            mEdtPickUp = FindViewById<EditText>(Resource.Id.cHire_pickUp);
            mEdtPickUp_D = FindViewById<EditText>(Resource.Id.cHire_pickUp_D);
            mBtnCarHire = FindViewById<Button>(Resource.Id.cHire_btn);

            mBtnCarHire.Click += MBtnCarHire_Click;
            //Car List Spinner
      

            List<CarModel> carModel = new List<CarModel>();
            HttpClient client = new HttpClient();
            var uri = new Uri(url.rootUrl + url.UrlcarmodelGet);
            var data = await client.GetAsync(uri);
            var jsonData = await data.Content.ReadAsStringAsync();

            try { carModel=Newtonsoft.Json.JsonConvert.DeserializeObject<List<CarModel>>(jsonData); }
            catch (Exception ex) { Toast.MakeText(this, ex.Message, ToastLength.Long).Show(); }
            List<String> carList = new List<string>();
            if (carModel != null)
            {
               
                for(int x = 0; x <= carModel.Count - 1; x++)
                {
                    carList.Add(carModel[x].carImage);
                }
            }
            mCarList_spinner.ItemSelected += Spinner_ItemSelected;
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem,carList);
            //var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.car_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mCarList_spinner.Adapter = adapter;

            //Radio Group event
            //mRadio_oneWay.Selectedjk
            mEdtPickUp_D.Click += MEdtPickUp_D_Click;
        }
        protected override void OnResume()
        {
            base.OnResume();
            int brks = 0;

        }

        private void MEdtPickUp_D_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                mEdtPickUp_D.Text = time.Date.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private async void MBtnCarHire_Click(object sender, EventArgs e)
        {
          //  Intent intent = new Intent(Resource.Layout);
           /* if (mEdtDropOff.Text == "") mEdtDropOff.Error = "Dropoff address required";
            else if (mEdtPickUp.Text == "") mEdtPickUp.Error = "Pickup address required";
            else if (mEdtPickUp_D.Text == "") mEdtPickUp_D.Error = "Pickup date required";
            else
            {
                Carhire carhire;
                    
                carhire = new Carhire
                {
                    DropOff = mEdtDropOff.Text,
                    pickUp = mEdtPickUp.Text,
                    CarName = mCarName,
                    IsReturn = mRadio_return.Checked,
                    PickDate = DateTime.Parse(mEdtPickUp_D.Text)
                };
                HttpClient client = new HttpClient();
                
                var uri = new Uri(url.rootUrl+url.UrlCarhirePost);
                var data = JsonConvert.SerializeObject(carhire);
                var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponse = await client.PostAsync(uri, httpContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK) {
                  //  Intent intent=new Intent(Resource.Layout.  )
                    //Toast.MakeText(this, "", ToastLength.Long).Show();
                }
                else Toast.MakeText(this, "", ToastLength.Long).Show();
                // var json = await result.Content.ReadAsStringAsync();
                int brk = 0;
            }*/
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast =spinner.GetItemAtPosition(e.Position).ToString();
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            mCarName = toast;

                var url = "http://10.0.2.2:4344/image/" + toast;
                var imageBimap=HttpImage.GetImageBitmapFromUri(url);
                mCarView.SetImageBitmap(imageBimap);
        }
    }
}