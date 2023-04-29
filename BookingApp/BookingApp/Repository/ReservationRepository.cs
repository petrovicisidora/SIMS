using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookingApp.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private string path;
        private string delimiter;

        public ReservationRepository(string path, string delimiter)
        {
            this.path = path;
            this.delimiter = delimiter;
        }
        public Reservation Create(Reservation reservation)
        {
            if (!GetAll().Any())
            {
                reservation.Id = 1;
            }
            else
            {
                reservation.Id = GetAll().Select(r => r.Id).Max() + 1;
            }
            AppendLineToFile(path, ConvertModelToCsvFormat(reservation));
            return reservation;
        }

        public bool Delete(Reservation reservation)
        {
            var reservations = GetAll().ToList();
            var newFile = new List<string>();
            var isDeleted = false;
            foreach (Reservation r in reservations)
            {
                if (r.Id == reservation.Id)
                {
                    isDeleted = true;
                }
                else
                {
                    newFile.Add(ConvertModelToCsvFormat(r));
                }
            }

            File.WriteAllLines(path, newFile);
            return isDeleted;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel);
        }

        public IEnumerable<Reservation> GetByHotelsCodeAndApartment(string code, string name)
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel).Where(r => r.HotelCode == code && r.ApartmentName == name);
        }

        public IEnumerable<Reservation> GetByUsersJMBG(string jmbg)
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel).Where(r => r.UsersJMBG == jmbg);
        }

        public Reservation Update(Reservation reservation)
        {
            var reservations = GetAll().ToList();
            var newFile = new List<string>();
            foreach (Reservation r in reservations)
            {

                if (r.Id == reservation.Id)
                {
                    r.UsersJMBG = reservation.UsersJMBG;
                    r.Date = reservation.Date;
                    r.HotelCode = reservation.HotelCode;
                    r.ApartmentName = reservation.ApartmentName;
                    r.Approved = reservation.Approved;
                    r.Message = reservation.Message;
                }
                newFile.Add(ConvertModelToCsvFormat(r));
            }

            File.WriteAllLines(path, newFile);
            return reservation;
        }

        private Reservation ConvertCsvFormatToModel(string csvFormat)
        {
            var tokens = csvFormat.Split(delimiter.ToCharArray());
            return new Reservation(
                Int32.Parse(tokens[0]),
                tokens[1],
                DateTime.Parse(tokens[2]),
                tokens[3],
                tokens[4],
                Boolean.Parse(tokens[5]),
                tokens[6]);
        }

        private string ConvertModelToCsvFormat(Reservation model)
        {
            return string.Join(delimiter,
                model.Id,
                model.UsersJMBG,
                model.Date,
                model.HotelCode,
                model.ApartmentName,
                model.Approved,
                model.Message);
        }

        private void AppendLineToFile(String path, String line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
