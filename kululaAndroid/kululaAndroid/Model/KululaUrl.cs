using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace kululaAndroid.Model
{
    class KululaUrl
    {
        private string rooturl= "http://10.0.2.2:4344";
        private string urlcarhirePost = "/api/Carhires";
        private string urlcarmodelGet = "/api/CarModels";
        private string urlflightbookPost = "/api/FlightBooks";
        private string urlpaymentPost = "api/Payments";
        private string urlloginPost = "/token";
        private string urlregisterPost = "/api/account/register";
        private string urlseatbookPost = "";
        private string urladdFlightschedulePost = "";
        private string urladdCarPost = "";
        private string urladdFlightPost = "";
        private string urlScheduleListGet = "/api/FlightBooks";
        private string urladdSchedulePost = "/api/FlightSchedule";
        private string urlclientDetailsPost = "/api/account/details";
        private string urlmodifyClientDetailPut = "/api/account/Details/modify";
        private string urlmodifyClientDetailGet = "/api/account/Details/get/";
        private string urlmemberPaymentGet= "/api/MemberDiscount/5";
        private string urlcarReceiptGet= "/api/Carhires/5";
        private string urlflightReceiptGet = "/api/FlightBppks/5";
        private string urlseatbookReceiptGet = "/api/SeatBooks/5";
        private string urlcarHistoryGet = "/api/dashboards/";
        private string urlflightHistoryGet = "/api/dashboards/";
        private string urldiscountHistoryGet = "/api/dashboards/";
        private string urlchangePasswordPost = "/api/Account/ChangePassword";
        private string urlaccActivationGet = "/api/Account/VerifyAccount/";
        private string urlemailTickePost = "";
        private string urladdTravellersPost = "";


        public string AuntheticationData(string Username,string Password)
        {
            return "username=" + Username + "&password=" + Password + "&grant_type=password";
        }
        public string UrlScheduleListGet { private set => urlScheduleListGet = value; get => urlScheduleListGet; }
        public string UrlcarmodelGet { private set => urlcarmodelGet = value; get => urlcarmodelGet; }
        public string UrlCarhirePost { private set => urlcarhirePost = value; get => urlcarhirePost; }
        public string UrlFlightbookPost { private set => urlflightbookPost = value; get => urlflightbookPost; }
        public string UrlPaymentPost { private set => urlpaymentPost = value; get => urlpaymentPost; }
        public string UrlLoginPost { private set => urlloginPost = value; get => urlloginPost; }
        public string UrlRegisterPost { private set => urlregisterPost = value; get => urlregisterPost; }
        public string UrlSeatbookPost { private set => urlseatbookPost = value; get => urlseatbookPost; }
        public string UrlAddFlightschedulePost { private set => urladdFlightschedulePost = value; get => urladdFlightschedulePost; }
        public string UrlAddCarPost { private set => urladdCarPost = value; get => urladdCarPost; }
        public string UrlAddFlightPost { private set => urladdFlightPost = value; get => urladdFlightPost; }
        public string UrlAddSchedulePost { private set => urladdSchedulePost = value; get => urladdSchedulePost; }
        public string UrlClientDetailsPost { private set => urlclientDetailsPost = value; get => urlclientDetailsPost; }
        public string UrlModifyClientDetailPut { private set => urlmodifyClientDetailPut = value; get => urlmodifyClientDetailPut; }
        public string UrlModifyClientDetailGet(string Id) { return urlmodifyClientDetailGet + Id; }
        public string UrlMemberPaymentGet { private set => urlmemberPaymentGet = value; get => urlmemberPaymentGet; }
        public string UrlCarReceiptGet { private set => urlcarReceiptGet = value; get => urlcarReceiptGet; }
        public string UrlFlightReceiptGet { private set => urlflightReceiptGet = value; get => urlflightReceiptGet; }
        public string UrlSeatbookReceiptGet { private set => urlseatbookReceiptGet = value; get => urlseatbookReceiptGet; }
        public string UrlCarHistoryGet(string username) { return urlcarHistoryGet + username + "/carhire"; }
        public string UrlFlightHistoryGet(string username) { return urlflightHistoryGet + username + "/flightbook"; }
        public string UrlDiscountHistoryGet(string username) { return urldiscountHistoryGet + username + "/discount"; }
        public string UrlChangePasswordPost { private set => urlchangePasswordPost = value; get => urlchangePasswordPost; }
        public string UrlAccActivationGet(string username) { return urlaccActivationGet + username; }
        public string UrlEmailTickePost { private set => urlemailTickePost = value; get => urlemailTickePost; }
        public string UrlAddTravellersPost { private set => urladdTravellersPost = value; get => urladdTravellersPost; }
        public string rootUrl{ private set =>rooturl=value; get=>rooturl; }
    }
}