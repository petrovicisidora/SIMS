using BookingApp.Model;
using System.Collections.Generic;

namespace BookingApp.Repository
{
    public interface IHotelRepository
    {
        Hotel GetByCode(string code);
        IEnumerable<Hotel> GetAll();
        Hotel Create(Hotel hotel);
        Hotel Update(Hotel hotel);
        bool Delete(Hotel hotel);
    }
}
