using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    class HttpImage
    {
        public static Bitmap GetImageBitmapFromUri(string url)
        {
            Bitmap ImageBitmap = null;
    
            using (var webClient=new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                
                if(imageBytes != null && imageBytes.Length > 0)
                {
                    ImageBitmap= BitmapFactory.DecodeByteArray(imageBytes, 0,imageBytes.Length);
                }
            }
            return ImageBitmap;
        }
    }
}