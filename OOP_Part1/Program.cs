namespace OOP_Part1
{
    internal class Program
    {
        // System Lists
        static List<Room> rooms = new List<Room>();
        static List<Guest> guests = new List<Guest>();
        
        // Guest Counter
        private static int guestCounter = 0;


        public static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"================================================\r\n\n{header.ToUpper()}\r\n\n================================================");
            Console.ResetColor();
        }

        public static int GetRoomNumber()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nEnter room number (0 to back): ");
            Console.ResetColor();


            if (!int.TryParse(Console.ReadLine(), out int roomNum) || roomNum <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  Error: Invalid room number. Press Enter.");
                Console.ResetColor();
                Console.ReadLine();
                return 0;
            }

            return roomNum;
        }

        public static string? GetGuestID()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nEnter guest ID: ");
            Console.ResetColor();

            return Console.ReadLine()?.Trim().ToUpper();
        }

        public static void AddNewRoom()
        {
            try
            {
                DisplayHeader("ADD NEW ROOM");
                
                string roomNumber = GetRoomNumber().ToString();
                if (roomNumber == "0") return;

                if (rooms.Any(r => r.roomNumber == roomNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Error: Room number alredy exists. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nEnter room type (Single / Double / Suite): ");
                Console.ResetColor();

                RoomType roomType;
                switch(Console.ReadLine()?.Trim().ToLower())
                {
                    case "single":
                        roomType = RoomType.Single;
                        break;
                    case "double":
                        roomType = RoomType.Double;
                        break;
                    case "suite":
                        roomType = RoomType.Suite;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n  Error: Invalid room type. Press Enter.");
                        Console.ResetColor();
                        Console.ReadLine();
                        return;
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nEnter price per night: ");
                Console.ResetColor();

                if (!double.TryParse(Console.ReadLine(), out double pricePerNight))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Error: Invalid price. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                // Create new Room object and add it to the room list
                rooms.Add(new Room(roomNumber, roomType, pricePerNight));

                Console.ForegroundColor = ConsoleColor.White;
                rooms[rooms.Count - 1].DisplayRoom();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n  Room {roomNumber} added successfully. Total rooms: {rooms.Count}");
                Console.ResetColor();
                Console.ReadLine();
            }
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAn unexpected error occurred:");
                Console.WriteLine(ex.Message);
                Console.ResetColor();

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        public static void RegisterNewGuest()
        {
            try
            {
                DisplayHeader("REGISTER NEW GUEST");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nEnter guest name: ");
                Console.ResetColor();

                string? guestName = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(guestName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Error: Invalid guest name. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nEnter check-in date (yyyy-MM-dd): ");
                Console.ResetColor();

                if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly checkInDate) || checkInDate < DateOnly.FromDateTime(DateTime.Now))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Error: Invalid check-in date. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nEnter number of nights: ");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out int totalNights) || totalNights <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Error: Invalid number of nights. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                string guestId = "G" + (++guestCounter).ToString("D3");

                string roomNumber = "Not Assigned";

                Guest newGuest = new Guest(guestId, guestName, roomNumber, checkInDate, totalNights);

                guests.Add(newGuest);

                Console.ForegroundColor = ConsoleColor.White;
                newGuest.DisplayGuest();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n  Guest registered successfully. Total guests: {guests.Count}");
                Console.ResetColor();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAn unexpected error occurred:");
                Console.WriteLine(ex.Message);
                Console.ResetColor();

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        public static void BookRoom()
        {
            try
            {
                DisplayHeader("BOOK A ROOM FOR A GUEST");

                string? guestId = GetGuestID();
                if (guestId == null) return;

                string roomNumber = GetRoomNumber().ToString();
                if (roomNumber == "0") return;

                Room?  room  = rooms.FirstOrDefault(r => r.roomNumber == roomNumber);
                if (room == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  No room with such number. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                Guest? guest = guests.FirstOrDefault(g => g.guestId == guestId);
                if (guest == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  No guest with such ID. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                if (!room.isAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Room is already booked. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                //  Assign the room number to the guest's roomNumber field
                guest.roomNumber = roomNumber;

                // Set the room's isAvailable to false
                room.isAvailable = false;

                // Total Cost
                double totalCost = guest.CalculateTotalCost(rooms);

                Console.ForegroundColor = ConsoleColor.White;
                guest.DisplayGuest();
                room.DisplayRoom();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n  Total Cost: {totalCost:F2} OMR");
                Console.ResetColor();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAn unexpected error occurred:");
                Console.WriteLine(ex.Message);
                Console.ResetColor();

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        public static void ShowAvailableRooms()
        {
            DisplayHeader("available rooms");

            List<Room> availableRooms = rooms.Where(r => r.isAvailable)
                                             .OrderBy(r => r.pricePerNight)
                                             .ToList();

            for (int i = 0; i < availableRooms.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n[{i+1}]"); availableRooms[i].DisplayRoom();
                Console.ResetColor();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTotal available rooms: {availableRooms.Count}");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void SearchFilterRooms()
        {
            DisplayHeader("Search & Filter Rooms");

            // Display sub-menu
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n(1) Show all available rooms\n(2) Filter by room type\n(3) Filter by max price\n(4) Room price statistics\n(0) Back");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nSelect option: ");
            Console.ResetColor();

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    ShowAvailableRooms();
                    break;
                
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Invalid option. Press Enter to try again.");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }

        public static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("================================================\r\n\nGRAND VISTA HOTEL — MANAGEMENT SYSTEM\r\n\n================================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n1. Add New Room\r\n\n2. Register New Guest\r\n\n3. Book a Room for a Guest");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n4. Search & Filter Rooms\r\n\n5. Guest & Booking Statistics");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n6. Check Out a Guest\r\n\n7. Remove Unavailable Rooms");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n0. Exit");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n================================================\r\n\nEnter your choice: ");
                Console.ResetColor();

                switch (Console.ReadLine())
                {
                    case "1":
                        AddNewRoom();
                        break;
                        
                    case "2":
                        RegisterNewGuest();
                        break;

                    case "3":
                        BookRoom();
                        break;

                    case "4":
                        SearchFilterRooms();
                        break;

                    case "5":
                        // Guest & Booking Statistics
                        break;

                    case "6":
                        // Check Out a Guest
                        break;

                    case "7":
                        // Remove Unavailable Rooms
                        break;
                   
                    case "0":
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n  Invalid option. Press Enter to try again.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }
        
        static void Main(string[] args)
        {
            // Pre-load 6 rooms
            rooms.Add(new Room("101", RoomType.Single, 22.1));
            rooms.Add(new Room("102", RoomType.Single, 23.5));
            rooms.Add(new Room("201", RoomType.Double, 30.8));
            rooms.Add(new Room("202", RoomType.Double, 36.7));
            rooms.Add(new Room("301", RoomType.Suite, 40.5));
            rooms.Add(new Room("302", RoomType.Suite, 45.99));


            MainMenu();
        }
    }
}
