using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookingApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private string path;
        private string delimiter;

        public UserRepository(string path, string delimiter)
        {
            this.path = path;
            this.delimiter = delimiter;
        }

        public User Create(User user)
        {
            AppendLineToFile(path, ConvertModelToCsvFormat(user));
            return user;
        }

        public bool Delete(User user)
        {
            var users = GetAll().ToList();
            var newFile = new List<string>();
            var isDeleted = false;
            foreach (User u in users)
            {
                if (u.JMBG == user.JMBG)
                {
                    isDeleted = true;
                }
                else
                {
                    newFile.Add(ConvertModelToCsvFormat(u));
                }
            }

            File.WriteAllLines(path, newFile);
            return isDeleted;
        }

        public IEnumerable<User> GetAll()
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel);
        }

        public User GetByEmail(string email)
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel).Where(u => u.Email == email).FirstOrDefault();
        }

        public User GetByJMBG(string jmbg)
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel).Where(u => u.JMBG == jmbg).FirstOrDefault();
        }

        public User Update(User user)
        {
            var users = GetAll().ToList();
            var newFile = new List<string>();
            foreach (User u in users)
            {

                if (u.JMBG == user.JMBG)
                {
                    u.Name = user.Name;
                    u.Surname = user.Surname;
                    u.Phone = user.Phone;
                    u.Role = user.Role;
                    u.Blocked = user.Blocked;
                }
                newFile.Add(ConvertModelToCsvFormat(u));
            }

            File.WriteAllLines(path, newFile);
            return user;
        }

        private User ConvertCsvFormatToModel(string csvFormat)
        {
            var tokens = csvFormat.Split(delimiter.ToCharArray());
            return new User(
                tokens[0],
                tokens[1],
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                tokens[6],
                bool.Parse(tokens[7]));
        }

        private string ConvertModelToCsvFormat(User model)
        {
            return string.Join(delimiter,
                model.JMBG,
                model.Email,
                model.Password,
                model.Name,
                model.Surname,
                model.Phone,
                model.Role,
                model.Blocked);
        }

        private void AppendLineToFile(String path, String line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
