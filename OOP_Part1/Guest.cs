using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Part1
{
    internal class Guest
    {
        public string   guestId {  get; }
        public string   guestName { get; set; }
        public string   roomNumber { get; set; }
        public DateOnly checkInDate { get; set; }
        public int      totalNights { get; set; }

        public Guest(string guestId, string guestName, string roomNumber, DateOnly checkInDate, int totalNights)
        {
            this.guestId = guestId;
            this.guestName = guestName;
            this.roomNumber = roomNumber;
            this.checkInDate = checkInDate;
            this.totalNights = totalNights;
        }

        public void DisplayGuest()
        {
            Console.WriteLine($"Guest ID: {guestId}\n" +
                $"Guest Name: {guestName}\n" +
                $"Room Number: {roomNumber}\n" +
                $"Check-In Date: {checkInDate}\n" +
                $"Total Nights: {totalNights}");
        }

        public double CalculateTotalCost(List<Room> rooms)
        {
            var room = rooms.FirstOrDefault(r => r.roomNumber == this.roomNumber);
            return room == null ? 0 : (room.pricePerNight * totalNights);
        }
    }
}
