using BookingApp.Model;
using BookingApp.Model.DTO;
using BookingApp.Service;
using System.Collections.Generic;

namespace BookingApp.Controller
{
    public class HotelController
    {
        private HotelService hotelService;
        public HotelController(HotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public IEnumerable<Hotel> GetAll(HotelsSearchQuery hotelsSearchQuery = null)
        {
            return hotelService.GetAll(hotelsSearchQuery);
        }
        public IEnumerable<Hotel> GetOwnersHotels(string jmbg)
        {
            return hotelService.GetOwnersHotels(jmbg);
        }

        public bool ApproveHotel(string code)
        {
            return hotelService.ApproveHotel(code);
        }

        public bool DeleteHotel(string code)
        {
            return hotelService.DeleteHotel(code);
        }

        public bool CreateHotel(Hotel hotel)
        {
            return hotelService.CreateHotel(hotel);
        }
    }
}
