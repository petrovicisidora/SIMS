using BookingApp.Model;
using BookingApp.Model.DTO;
using BookingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Service
{
    public class HotelService
    {
        private IHotelRepository hotelRepository;
        private IApartmentRepository apartmentRepository;
        public HotelService(IHotelRepository hotelRepository, IApartmentRepository apartmentRepository)
        {
            this.hotelRepository = hotelRepository;
            this.apartmentRepository = apartmentRepository;
        }

        public IEnumerable<Hotel> GetAll(HotelsSearchQuery hotelsSearchQuery = null)
        {
            var rawHotels = hotelRepository.GetAll().Where(h => h.Accepted);
            var hotels = new List<Hotel>();
            foreach (var hotel in rawHotels)
            {
                hotels.Add(IncludeApartmentsInHotel(hotel));
            }
            return Filter(hotels, hotelsSearchQuery);
        }

        public IEnumerable<Hotel> GetOwnersHotels(string jmbg)
        {
            return hotelRepository.GetAll().Where(h => h.OwnersJMBG == jmbg);
        }

        public bool ApproveHotel(string code)
        {
            var hotel = hotelRepository.GetByCode(code);
            if (hotel == null)
            {
                return false;
            }
            hotel.Accepted = true;
            hotelRepository.Update(hotel);
            return true;
        }

        public bool DeleteHotel(string code)
        {
            var hotel = hotelRepository.GetByCode(code);
            if (hotel == null)
            {
                return false;
            }
            hotelRepository.Delete(hotel);
            return true;
        }

        public bool CreateHotel(Hotel hotel)
        {
            if (hotelRepository.GetByCode(hotel.Code) != null)
            {
                return false;
            }
            hotelRepository.Create(hotel);
            return true;
        }

        private Hotel IncludeApartmentsInHotel(Hotel hotel)
        {
            var apartments = new Dictionary<string, Apartment>();
            foreach (var a in hotel.Apartments.Keys)
            {
                apartments[a] = apartmentRepository.GetByName(a);
            }
            hotel.Apartments = apartments;
            return hotel;
        }

        private IEnumerable<Hotel> Filter(IEnumerable<Hotel> hotels, HotelsSearchQuery hotelsSearchQuery)
        {
            if (hotelsSearchQuery == null)
            {
                return hotels;
            }
            switch (hotelsSearchQuery.SearchType)
            {
                case "Code":
                    return hotels.Where(h => h.Code.ToLower().Contains(hotelsSearchQuery.SearchValue.ToLower()));
                case "Name":
                    return hotels.Where(h => h.Name.ToLower().Contains(hotelsSearchQuery.SearchValue.ToLower()));
                case "Year of building":
                    return hotels.Where(h => h.YearOfBuilding == Int32.Parse(hotelsSearchQuery.SearchValue));
                case "Stars":
                    return hotels.Where(h => h.StarsRating == Int32.Parse(hotelsSearchQuery.SearchValue));
                case "Apartments":
                    return AdvancedFilter(hotels, hotelsSearchQuery);
                default:
                    return hotels;
            }
        }

        private IEnumerable<Hotel> AdvancedFilter(IEnumerable<Hotel> hotels, HotelsSearchQuery hotelsSearchQuery)
        {
            switch (hotelsSearchQuery.AdditionalSearchType)
            {
                case "Rooms":
                    return hotels.Where(h => h.Apartments.Select(e => e.Value)
                                                .Where(a => a.RoomCount == Int32.Parse(hotelsSearchQuery.SearchValue)).Any());
                case "Guests":
                    return hotels.Where(h => h.Apartments.Select(e => e.Value)
                                                .Where(a => a.Capacity == Int32.Parse(hotelsSearchQuery.SearchValue)).Any());
                case "Rooms & Guests":
                    return hotelsSearchQuery.Connection ?
                        hotels.Where(h => h.Apartments.Select(e => e.Value)
                                                .Where(a => a.RoomCount == Int32.Parse(hotelsSearchQuery.SearchValue)).Any() &&
                                          h.Apartments.Select(e => e.Value)
                                                .Where(a => a.Capacity == Int32.Parse(hotelsSearchQuery.AdditionalSearchValue)).Any()) :
                        hotels.Where(h => h.Apartments.Select(e => e.Value)
                                                .Where(a => a.RoomCount == Int32.Parse(hotelsSearchQuery.SearchValue)).Any() ||
                                          h.Apartments.Select(e => e.Value)
                                                .Where(a => a.Capacity == Int32.Parse(hotelsSearchQuery.AdditionalSearchValue)).Any());
                default:
                    return hotels;
            }
        }
    }
}
