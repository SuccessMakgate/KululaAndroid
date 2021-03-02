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

namespace kululaAndroid.Model
{
    class FlightScheduleAdapter:BaseAdapter<FlightSchedule>
    {
        private List<FlightSchedule> mItems = new List<FlightSchedule>();
        
        private Context mContent;

        public FlightScheduleAdapter(Context context, List<FlightSchedule> Items)
        {
            mItems = Items;
            mContent = context;
        }
        public override int Count
        {
            get { return mItems.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override FlightSchedule this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null) row = LayoutInflater.From(mContent).Inflate(Resource.Menu.fScheduleList, null, false);
            

            TextView mDepatureDate = row.FindViewById<TextView>(Resource.Id.Sch_depatureD);
            mDepatureDate.Text = mItems[position].DepartDate.ToShortDateString();

            TextView mDepatureTime = row.FindViewById<TextView>(Resource.Id.Sch_depatureT);
            mDepatureTime.Text = mItems[position].DepartTime.ToShortTimeString();

            for (int x=0; x< mItems[position].aircrafts.Count;x++)
            {
                TextView mFlightName = row.FindViewById<TextView>(Resource.Id.Sch_flightName);
                string Flight = mItems[position].aircrafts[x].AircraftName + " #" + mItems[position].aircrafts[x].AircraftNo;
                mFlightName.Text = Flight;

                TextView mPrice = row.FindViewById<TextView>(Resource.Id.Sch_price);
                mPrice.Text = mItems[position].aircrafts[x].price.ToString();

                TextView mSeatLeft = row.FindViewById<TextView>(Resource.Id.Sch_seatLeft);
                int seatLeft = mItems[position].aircrafts[x].MaxSeats - mItems[position].aircrafts[x].NumSeatBooked;
                mSeatLeft.Text = seatLeft.ToString();

                ImageView FlightLogo = row.FindViewById<ImageView>(Resource.Id.Sch_flightImg);

                var url = "http://10.0.2.2:4344/image/" + (mItems[position].aircrafts[x].AircraftLogo);
                var imageBimap = HttpImage.GetImageBitmapFromUri(url);
                FlightLogo.SetImageBitmap(imageBimap);
                int brk = 0;
            }
            return row;
        }
    }
}