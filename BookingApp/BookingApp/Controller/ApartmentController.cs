using BookingApp.Model;
using BookingApp.Service;

namespace BookingApp.Controller
{
    public class ApartmentController
    {
        private ApartmentService apartmentService;
        public ApartmentController(ApartmentService apartmentService)
        {
            this.apartmentService = apartmentService;
        }

        public bool CreateNewApartment(Apartment apartment, Hotel hotel)
        {
            return apartmentService.CreateNewApartment(apartment, hotel);
        }
    }
}
