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
    public class Aircraft
    {
        public int AircraftId { get; set; } 
        public string AircraftNo { get; set; }
        public string AircraftName { get; set; }
        public int MaxSeats { get; set; } 
        public int NumSeatBooked { get; set; }
        public string AircraftLogo { get; set; }
        public bool IsFlightFull { get; set; }
        public int price { get; set; }
    }
    public class SeatBooking
    {
        public int SeatBookingId { get; set; } 
        public int SeatNumber { get; set; } 
        public int SeatPrice { get; set; }
        public string SeatName { get; set; }
        public bool PaymentStatus { get; set; }

    }
    public class FlightExtra
    {
        public int FlightExtraId { get; set; }
        public bool InlPets { get; set; }
        public bool InlInsurance { get; set; }
        public bool InlMeal { get; set; }
        public double ExPrice { get; set; }
    }
    public class Traveller
    {
        public int TravellerId { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

    }
    public class Carhire
    {
        public int carHireId { get; set; }
        public string pickUp { get; set; }
        public string DropOff { get; set; }
        public bool IsReturn { get; set; }
        public DateTime PickDate { get; set; }
        public string CarName { get; set; }
        public bool PaymentStatus { get; set; }
        public string memberIDC { get; set; }

    }
    public class CarModel
    {  
        public string CarName { get; set; }
        public string CarColour { get; set; }
        public string YearModel { get; set; }
        public bool LeatherSeat { get; set; }
        public bool Radio_Cd { get; set; }
        public bool AirBag { get; set; }
        public int price { get; set; }
        public string carImage { get; set; }

        public List<Carhire> Cars { get; set; }

    }
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public Register(string _email,string _password,string _confirmPassword)
        {
            Email = _email;
            Password = _password;
            ConfirmPassword = _confirmPassword;
        }
    }
    public class Client
    {
        public int ClientID { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }

    }
    public class Payment
    {
        public int PaymentId { get; set; }
        public string payMethod { get; set; } 
        public string AccHolder { get; set; }
        public string AccountNo { get; set; }
        public string CardNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsCarhire { get; set; }
        public bool IsSeatBook { get; set; }
    }
    public class MemberDiscount
    {
        public string DiscountRef { get; set; }
        public string MembersEmail { get; set; }
        public DateTime TransnDate { get; set; }
        public double discount { get; set; }
        public int kululaPoints { get; set; }
        public int PaymentId { get; set; }
    }
    public class FlightBooks
    {
        public int FlightBookId { get; set; }
        public string DestPlace { get; set; }
        public string DepartPlace { get; set; }
        public DateTime DepartDate { get; set; }
        public DateTime returnDate { get; set; }
        public bool IsReturn { get; set; }
        public int NumPeople { get; set; }
        public bool IsScheduleFound { get; set; }
        public string memberIDF { get; set; }
        public int FlightScheduleId { get; set; }
    }
    public class FlightSchedule
    {
        public int FlightScheduleId { get; set; } 
        public DateTime DepartDate { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnTime { get; set; }
        public List<Aircraft> aircrafts { get; set; }
    }
}