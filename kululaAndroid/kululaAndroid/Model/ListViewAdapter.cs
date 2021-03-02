using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace kululaAndroid.Model
{
    class ListViewAdapter: BaseAdapter<Groceries>
    {
        private List<Groceries> mItems;
        private Context mContent;

        public ListViewAdapter(Context context, List<Groceries> Items)
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
        public override Groceries this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null) row = LayoutInflater.From(mContent).Inflate(Resource.Menu.fScheduleList, null, false);

            TextView Text1 = row.FindViewById<TextView>(Resource.Id.Sch_depatureD);
            Text1.Text = mItems[position].Name;

            TextView Text2 = row.FindViewById<TextView>(Resource.Id.Sch_depatureT);
            Text2.Text = mItems[position].Category;

            ImageView image = row.FindViewById<ImageView>(Resource.Id.Sch_flightImg);

            // grab the old image and dispose of it
            /*   if (image.Drawable != null)
               {
                   using (var img = image.Drawable as BitmapDrawable)
                   {
                       if (img != null)
                       {
                           if (img.Bitmap != null)
                           {
                               //image.Bitmap.Recycle ();
                               img.Bitmap.Dispose();
                           }
                       }
                   }
               }*/
            // If a new image is required, display it
            if (!String.IsNullOrWhiteSpace(mItems[position].ImageFilename))
            {
                //------------------------------------
                ImageView imageView = row.FindViewById<ImageView>(Resource.Id.Sch_flightImg);

                // context.GetFileStreamPath(item.ImageFilename);
                imageView.BuildDrawingCache(true);
                Bitmap bitmaps = imageView.GetDrawingCache(true);

                BitmapDrawable drawable = (BitmapDrawable)imageView.Drawable;
                Bitmap bitmap = drawable.Bitmap;
                string src = "";
                Bitmap bitmap2 = BitmapFactory.DecodeFile(src);
                //  bitmap2 = BitmapFactory.DecodeResource(this, Resource.Drawable.Fruits);
                if (bitmap2 != null)
                {
                    row.FindViewById<ImageView>(Resource.Id.Sch_flightImg).SetImageBitmap(bitmap2);
                    bitmap2.Dispose();
                }
                //-----------------------------------

                /* context.Resources.GetBitmapAsync(item.ImageFilename).ContinueWith((t) => {
                     var bitmap = t.Result;
                     if (bitmap != null)
                     {
                         view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(bitmap2);
                         bitmap.Dispose();
                     }
                 }, TaskScheduler.FromCurrentSynchronizationContext());*/
            }
            else
            {
                // clear the image
                row.FindViewById<ImageView>(Resource.Id.Sch_flightImg).SetImageBitmap(null);
            }
            return row;
        }
    }
}