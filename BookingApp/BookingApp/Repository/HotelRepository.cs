using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookingApp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private string path;
        private string delimiter;

        public HotelRepository(string path, string delimiter)
        {
            this.path = path;
            this.delimiter = delimiter;
        }

        public Hotel Create(Hotel hotel)
        {
            AppendLineToFile(path, ConvertModelToCsvFormat(hotel));
            return hotel;
        }

        public bool Delete(Hotel hotel)
        {
            var hotels = GetAll().ToList();
            var newFile = new List<string>();
            var isDeleted = false;
            foreach (Hotel h in hotels)
            {
                if (h.Code == hotel.Code)
                {
                    isDeleted = true;
                }
                else
                {
                    newFile.Add(ConvertModelToCsvFormat(h));
                }
            }

            File.WriteAllLines(path, newFile);
            return isDeleted;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel);
        }

        public Hotel GetByCode(string code)
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel).Where(h => h.Code == code).FirstOrDefault();
        }

        public Hotel Update(Hotel hotel)
        {
            var hotels = GetAll().ToList();
            var newFile = new List<string>();
            foreach (Hotel h in hotels)
            {
                if (h.Code == hotel.Code)
                {
                    h.Name = hotel.Name;
                    h.YearOfBuilding = hotel.YearOfBuilding;
                    h.Apartments = hotel.Apartments;
                    h.StarsRating = hotel.StarsRating;
                    h.OwnersJMBG = hotel.OwnersJMBG;
                    h.Accepted = hotel.Accepted;
                }
                newFile.Add(ConvertModelToCsvFormat(h));
            }
            File.WriteAllLines(path, newFile);
            return hotel;
        }

        private Hotel ConvertCsvFormatToModel(string csvFormat)
        {
            var tokens = csvFormat.Split(delimiter.ToCharArray());
            var apartments = tokens[3].Split('`');
            var dictionary = new Dictionary<string, Apartment>();
            foreach (var a in apartments)
            {
                if (a != "")
                    dictionary.Add(a, null);
            }
            return new Hotel(
                tokens[0],
                tokens[1],
                int.Parse(tokens[2]),
                dictionary,
                int.Parse(tokens[4]),
                tokens[5],
                bool.Parse(tokens[6]));
        }

        private string ConvertModelToCsvFormat(Hotel model)
        {
            string keys = string.Empty;
            foreach (var a in model.Apartments.Keys)
            {
                keys += a;
                if (a != model.Apartments.Keys.Last())
                {
                    keys += "`";
                }
            }
            return string.Join(delimiter,
                model.Code,
                model.Name,
                model.YearOfBuilding,
                keys,
                model.StarsRating,
                model.OwnersJMBG,
                model.Accepted);
        }

        private void AppendLineToFile(String path, String line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
