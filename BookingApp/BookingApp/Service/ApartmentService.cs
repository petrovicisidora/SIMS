using BookingApp.Model;
using BookingApp.Repository;

namespace BookingApp.Service
{
    public class ApartmentService
    {
        private IHotelRepository hotelRepository;
        private IApartmentRepository apartmentRepository;

        public ApartmentService(IHotelRepository hotelRepository, IApartmentRepository apartmentRepository)
        {
            this.hotelRepository = hotelRepository;
            this.apartmentRepository = apartmentRepository;
        }

        public bool CreateNewApartment(Apartment apartment, Hotel hotel)
        {
            var check = apartmentRepository.GetByName(apartment.Name);
            if (check != null)
            {
                return false;
            }
            apartmentRepository.Create(apartment);
            hotel.Apartments.Add(apartment.Name, apartment);
            hotelRepository.Update(hotel);
            return true;
        }
    }
}
