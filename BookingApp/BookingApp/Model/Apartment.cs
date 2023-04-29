using System;

namespace BookingApp.Model
{
    public class Apartment : ICloneable
    {
        public Apartment(string name, string description, int roomCount, int capacity)
        {
            Name = name;
            Description = description;
            RoomCount = roomCount;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomCount { get; set; }
        public int Capacity { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
