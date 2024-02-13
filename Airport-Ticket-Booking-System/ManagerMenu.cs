namespace Airport_Ticket_Booking_System
{
    public static class ManagerMenu
    {
        public static void Open(FileSystem fileSystem)
        {
            bool menu = true;

            while (menu)
            {
                Console.Clear();
                Console.WriteLine("***Manager Interface***");                
                Console.WriteLine("1. Filter Bookings");
                Console.WriteLine("2. Import Flights from Csv");
                Console.WriteLine("3. Manage Bookings");
                Console.WriteLine("4. Exit");
                Console.Write("Enter an option (1-4): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            FilerBookings(fileSystem);           
                            break;
                        case 2:
                            // Upload Flights from file
                            ImportFlights(fileSystem);
                            break;
                        case 3:
                            // Manage Bookings
                            break;
                        case 4:
                            menu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice option");
                            break;
                    }
                }
                else Console.WriteLine("Invalid choice option");
            }
        }

        private static void FilerBookings(FileSystem fileSystem)
        {
            Console.Clear();
            Console.WriteLine("***Filter Bookings***");
            Console.WriteLine("Filter By:");
            Console.WriteLine("1. Flight");
            Console.WriteLine("2. Price");
            Console.WriteLine("3. Departure Country");
            Console.WriteLine("4. Destination Country");
            Console.WriteLine("5. Departure Date");
            Console.WriteLine("6. Departure Airport");
            Console.WriteLine("7. Arrival Airport");
            Console.WriteLine("8. Passanger");
            Console.WriteLine("9. Class");
            Console.Write("Enter an option (1-): ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        FilerBookings(fileSystem);
                        break;
                    case 2:
                        // Upload Flights from file
                        ImportFlights(fileSystem);
                        break;
                    case 3:
                        // Manage Bookings
                        break;
                    case 10:                       
                        break;

                    default:
                        Console.WriteLine("Invalid choice option");
                        break;
                }
            }
            else Console.WriteLine("Invalid choice option");
        }

        private static void ImportFlights(FileSystem fileSystem)
        {
            Console.WriteLine("Enter File Path");
            string filePath = Console.ReadLine();
            fileSystem.ImportFlightsFromCsv(filePath);

        }
    }
}