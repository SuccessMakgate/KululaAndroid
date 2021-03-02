using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace kululaAndroid.Model
{
    public class CarhireFragment : Fragment
    {
        Context thisContext;
        KululaUrl url = new KululaUrl();
        private ProgressBar mProgressBar;
        private Spinner mCarList_spinner;
        private ImageView mCarView;
        private EditText mEdtPickUp, mEdtDropOff, mEdtPickUp_D;
        private RadioButton mRadio_return, mRadio_oneWay;
        private Button mBtnCarHire;
        private string mCarName;
        private ArrayAdapter adapter;
        public async override void OnStart()
        {
            base.OnStart();
            mProgressBar.Visibility = ViewStates.Visible;

            //Get list of cars from the server into spinner(Dropdown)
          //  SpinnerData(thisContext);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.carhire_fragment, container, false);
            thisContext = container.Context;
            mRadio_oneWay = view.FindViewById<RadioButton>(Resource.Id.cHire_oneWay_radio);
            mRadio_return = view.FindViewById<RadioButton>(Resource.Id.cHire_return_radio);
            mCarList_spinner = view.FindViewById<Spinner>(Resource.Id.cHire_carList_spinner);
            mCarView = view.FindViewById<ImageView>(Resource.Id.cHire_CarView);
            mEdtDropOff = view.FindViewById<EditText>(Resource.Id.cHire_dropOff);
            mEdtPickUp = view.FindViewById<EditText>(Resource.Id.cHire_pickUp);
            mEdtPickUp_D = view.FindViewById<EditText>(Resource.Id.cHire_pickUp_D);
            mBtnCarHire = view.FindViewById<Button>(Resource.Id.cHire_btn);
            mProgressBar = view.FindViewById<ProgressBar>(Resource.Id.cHire_progressBar);

            mBtnCarHire.Click += MBtnCarHire_Click;
            //Car List Spinner
            
            mCarList_spinner.ItemSelected += Spinner_ItemSelected;

           

            //Radio Group event
            //mRadio_oneWay.Selectedjk
            mEdtPickUp_D.Click += MEdtPickUp_D_Click;

            return view;
        }
        private async void SpinnerData(Context context)
        {

            List<CarModel> carModel = new List<CarModel>();
            HttpClient client = new HttpClient();
            var uri = new System.Uri(url.rootUrl + url.UrlcarmodelGet);
            var data = await client.GetAsync(uri);
            var jsonData = await data.Content.ReadAsStringAsync();

            try { carModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CarModel>>(jsonData); }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
            List<String> carList = new List<string>();
            if (carModel != null)
            {

                for (int x = 0; x <= carModel.Count - 1; x++)
                {
                    carList.Add(carModel[x].carImage);
                }
            }
          
            adapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleSpinnerItem, carList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mCarList_spinner.Adapter = adapter;
            mProgressBar.Visibility = ViewStates.Invisible;
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
            if (mEdtDropOff.Text == "") mEdtDropOff.Error = "Dropoff address required";
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
              /*  HttpClient client = new HttpClient();

                var uri = new System.Uri(url.rootUrl + url.UrlCarhirePost);
                var data = JsonConvert.SerializeObject(carhire);
                var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponse = await client.PostAsync(uri, httpContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    FragmentTransaction transaction;
                    PaymentFragment payment = new PaymentFragment();
                    Intent intent = new Intent();
                    intent.PutExtra("IsFlightPayment", false);
                    transaction = this.FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, payment);
                    transaction.Commit();
                }
                else Toast.MakeText(thisContext, "Server Errror "+httpResponse.StatusCode, ToastLength.Long).Show();*/

                FragmentTransaction transaction;
                PaymentFragment payment = new PaymentFragment();
                Intent intent = new Intent();
                intent.PutExtra("IsFlightPayment", false);
                transaction = this.FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, payment);
                transaction.Commit();
            }

        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = spinner.GetItemAtPosition(e.Position).ToString();
            Toast.MakeText(e.Parent.Context, toast, ToastLength.Long).Show();
            mCarName = toast; 

            var url = "http://10.0.2.2:4344/image/" + toast;
            var imageBimap = HttpImage.GetImageBitmapFromUri(url);
            mCarView.SetImageBitmap(imageBimap);
        }
    }
}
