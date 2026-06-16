namespace OOP_Part1
{
    internal class Program
    {
        // System Lists
        static List<Room> rooms = new List<Room>();
        static List<Guest> guests = new List<Guest>();

        public static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"================================================\r\n\n{header.ToUpper()}\r\n\n================================================");
            Console.ResetColor();
        }

        public static void AddNewRoom()
        {
            try
            {
                DisplayHeader("ADD NEW ROOM");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nEnter room number: ");
                Console.ResetColor();

                
                if (!int.TryParse(Console.ReadLine(), out int roomNum) || roomNum <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Error: Invalid room number. Press Enter.");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                string roomNumber = roomNum.ToString();

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
                        // Register New Guest
                        break;

                    case "3":
                        // Book a Room for a Guest
                        break;

                    case "4":
                        // Search & Filter Rooms
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
