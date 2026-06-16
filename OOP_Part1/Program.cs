namespace OOP_Part1
{
    internal class Program
    {
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
                        //Add New Room
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
            MainMenu();
        }
    }
}
