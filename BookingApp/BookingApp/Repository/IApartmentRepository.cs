using BookingApp.Model;
using System.Collections.Generic;

namespace BookingApp.Repository
{
    public interface IApartmentRepository
    {
        Apartment GetByName(string name);
        IEnumerable<Apartment> GetAll();
        Apartment Create(Apartment apartment);
        Apartment Update(Apartment apartment);
        bool Delete(Apartment apartment);
    }
}
