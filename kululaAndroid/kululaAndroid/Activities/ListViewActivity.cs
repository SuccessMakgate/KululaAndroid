using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
    [Activity(Label = "Schedule")]
    public class ListViewActivity : Activity
    {
        private List<FlightSchedule> schedule;
        private TextView AirportAddress; 
        protected async  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

          
            SetContentView(Resource.Layout.ListLayout);

            KululaUrl url = new KululaUrl();     
            schedule = new List<FlightSchedule>();
            HttpClient client = new HttpClient();
            var uri = new Uri(url.rootUrl + url.UrlScheduleListGet);
            var data = await client.GetAsync(uri);
            var jsonData = await data.Content.ReadAsStringAsync();
         

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            serializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
            serializerSettings.Formatting= Newtonsoft.Json.Formatting.Indented; 
           

            try {
                schedule=  Newtonsoft.Json.JsonConvert.DeserializeObject<List<FlightSchedule>>(jsonData,serializerSettings );
            }
            catch (Exception ex) { Toast.MakeText(this, ex.Message, ToastLength.Long).Show(); }

            FlightScheduleAdapter listViewAdapter = new FlightScheduleAdapter(this, schedule);
            ListView mListView = FindViewById<ListView>(Resource.Id.kululaListView);
            mListView.Adapter = listViewAdapter;
            mListView.ItemClick += MListView_ItemClick;
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 2)
            {
               string dest= data.GetStringExtra("DepartAirport");
               string depart= data.GetStringExtra("DestAirport");
               string airportAddress = String.Format("From :"+dest+" To :"+depart);
               AirportAddress = FindViewById<TextView>(Resource.Id.Sch_AirportAddress);
               AirportAddress.Text=airportAddress;
            }
        }
        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           Console.WriteLine(schedule[e.Position].DepartDate);
        }
  
    }
}