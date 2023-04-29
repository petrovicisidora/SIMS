using BookingApp.Model;
using System.Collections.Generic;

namespace BookingApp.Repository
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetByUsersJMBG(string jmbg);
        IEnumerable<Reservation> GetByHotelsCodeAndApartment(string code, string name);
        IEnumerable<Reservation> GetAll();
        Reservation Create(Reservation reservation);
        Reservation Update(Reservation reservation);
        bool Delete(Reservation reservation);
    }
}
