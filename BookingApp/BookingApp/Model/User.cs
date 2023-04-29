using System;

namespace BookingApp.Model
{
    public class User : ICloneable
    {
        public User(string jmbg, string email, string password, string name, string surname, string phone, string role, bool blocked)
        {
            JMBG = jmbg;
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            Phone = phone;
            Role = role;
            Blocked = blocked;
        }

        public string JMBG { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public bool Blocked { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
