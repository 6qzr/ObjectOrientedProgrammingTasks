using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Part1
{
    public enum RoomType { Single, Double, Suite }
    internal class Room
    {
        public string   roomNumber { get; private set; }
        public RoomType roomType { get; private set; }
        public double   pricePerNight { get; private set; }
        public bool     isAvailable { get; set; }

        public Room(string roomNumber, RoomType roomType, double pricePerNight)
        {
            this.roomNumber = roomNumber;
            this.roomType = roomType;
            this.pricePerNight = pricePerNight;
            this.isAvailable = true; // always true on creation;
        }

        public void displayRoom() 
        {
            Console.WriteLine($"\nRoom: {roomNumber}  |   Type: {roomType}    |   Price: {pricePerNight:F2} OMR   |   Available: {isAvailable}");
        }
    }
}
