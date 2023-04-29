using BookingApp.Model;
using BookingApp.Service;
using System.Collections.Generic;

namespace BookingApp.Controller
{
    public class UserController
    {
        private UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        public IEnumerable<User> GetAll(string role = "BOTH")
        {
            return userService.GetAll(role);
        }
        public bool Register(User user)
        {
            return userService.Register(user);
        }

        public User Login(string email, string password)
        {
            return userService.Login(email, password);
        }

        public List<string> GetOwnersJMBG()
        {
            return userService.GetOwnersJMBG();
        }

        public bool ChangeBlocked(string jmbg)
        {
            return userService.ChangeBlocked(jmbg);
        }
    }
}
