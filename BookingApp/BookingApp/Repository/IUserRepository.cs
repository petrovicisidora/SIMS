using BookingApp.Model;
using System.Collections.Generic;

namespace BookingApp.Repository
{
    public interface IUserRepository
    {
        User GetByJMBG(string jmbg);
        User GetByEmail(string email);
        IEnumerable<User> GetAll();
        User Create(User user);
        User Update(User user);
        bool Delete(User user);
    }
}
