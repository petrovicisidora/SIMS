using System;

namespace BookingApp.Model
{
    public class Reservation : ICloneable
    {
        public Reservation(string usersJMBG, DateTime date, string hotelCode, string apartmentName, bool approved, string message)
        {
            UsersJMBG = usersJMBG;
            Date = date;
            HotelCode = hotelCode;
            ApartmentName = apartmentName;
            Approved = approved;
            Message = message;
        }

        public Reservation(int id, string usersJMBG, DateTime date, string hotelCode, string apartmentName, bool approved, string message)
        {
            Id = id;
            UsersJMBG = usersJMBG;
            Date = date;
            HotelCode = hotelCode;
            ApartmentName = apartmentName;
            Approved = approved;
            Message = message;
        }

        public int Id { get; set; }
        public string UsersJMBG { get; set; }
        public DateTime Date { get; set; }
        public string HotelCode { get; set; }
        public string ApartmentName { get; set; }
        public bool Approved { get; set; }
        public string Message { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
