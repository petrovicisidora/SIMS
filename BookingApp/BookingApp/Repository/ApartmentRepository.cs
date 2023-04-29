using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookingApp.Repository
{
    public class ApartmentRepository : IApartmentRepository
    {
        private string path;
        private string delimiter;

        public ApartmentRepository(string path, string delimiter)
        {
            this.path = path;
            this.delimiter = delimiter;
        }

        public Apartment Create(Apartment apartment)
        {
            AppendLineToFile(path, ConvertModelToCsvFormat(apartment));
            return apartment;
        }

        public bool Delete(Apartment apartment)
        {
            var apartments = GetAll().ToList();
            var newFile = new List<string>();
            var isDeleted = false;
            foreach (Apartment a in apartments)
            {
                if (a.Name == apartment.Name)
                {
                    isDeleted = true;
                }
                else
                {
                    newFile.Add(ConvertModelToCsvFormat(a));
                }
            }

            File.WriteAllLines(path, newFile);
            return isDeleted;
        }

        public IEnumerable<Apartment> GetAll()
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel);
        }

        public Apartment GetByName(string name)
        {
            return File.ReadAllLines(path).Select(ConvertCsvFormatToModel).Where(a => a.Name == name).FirstOrDefault();
        }

        public Apartment Update(Apartment apartment)
        {
            var apartments = GetAll().ToList();
            var newFile = new List<string>();
            foreach (Apartment a in apartments)
            {

                if (a.Name == apartment.Name)
                {
                    a.Description = apartment.Description;
                    a.RoomCount = apartment.RoomCount;
                    a.Capacity = apartment.Capacity;
                }
                newFile.Add(ConvertModelToCsvFormat(a));
            }

            File.WriteAllLines(path, newFile);
            return apartment;
        }

        private Apartment ConvertCsvFormatToModel(string csvFormat)
        {
            var tokens = csvFormat.Split(delimiter.ToCharArray());
            return new Apartment(
                tokens[0],
                tokens[1],
                Int32.Parse(tokens[2]),
                Int32.Parse(tokens[3]));
        }

        private string ConvertModelToCsvFormat(Apartment model)
        {
            return string.Join(delimiter,
                model.Name,
                model.Description,
                model.RoomCount,
                model.Capacity);
        }

        private void AppendLineToFile(String path, String line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
