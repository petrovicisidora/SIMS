using System;
using System.Collections.Generic;

namespace BookingApp.Model
{
    public class Hotel : ICloneable
    {
        public Hotel(string code, string name, int yearOfBuilding, Dictionary<string, Apartment> apartments, int starsRating, string ownersJMBG, bool accepted)
        {
            Code = code;
            Name = name;
            YearOfBuilding = yearOfBuilding;
            Apartments = apartments;
            StarsRating = starsRating;
            OwnersJMBG = ownersJMBG;
            Accepted = accepted;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public int YearOfBuilding { get; set; }
        public Dictionary<string, Apartment> Apartments { get; set; }
        public int StarsRating { get; set; }
        public string OwnersJMBG { get; set; }
        public bool Accepted { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
