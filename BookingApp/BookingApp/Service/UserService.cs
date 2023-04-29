using BookingApp.Model;
using BookingApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Service
{
    public class UserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetAll(string role = "BOTH")
        {
            if (role == "BOTH")
            {
                return userRepository.GetAll().Where(u => u.Role != "ADMIN");
            }
            return userRepository.GetAll().Where(u => u.Role != "ADMIN").Where(u => u.Role == role);
        }
        public bool Register(User user)
        {
            if (!CheckEmailAvailability(user.Email) || !CheckJMBGAvailability(user.JMBG))
            {
                return false;
            }
            userRepository.Create(user);
            return true;
        }

        public User Login(string email, string password)
        {
            var user = userRepository.GetByEmail(email);
            if (user == null)
            {
                return null;
            }
            if (user.Blocked)
            {
                return null;
            }
            if (user.Password == password)
            {
                return user;
            }
            return null;
        }

        public List<string> GetOwnersJMBG()
        {
            return userRepository.GetAll().Where(u => u.Role == "OWNER").Select(u => u.JMBG).ToList();
        }

        public bool ChangeBlocked(string jmbg)
        {
            var user = userRepository.GetByJMBG(jmbg);
            if (user == null)
            {
                return false;
            }
            user.Blocked = !user.Blocked;
            userRepository.Update(user);
            return true;
        }

        private bool CheckJMBGAvailability(string jmbg)
        {
            return userRepository.GetByJMBG(jmbg) == null;
        }

        private bool CheckEmailAvailability(string email)
        {
            return userRepository.GetByEmail(email) == null;
        }
    }
}
