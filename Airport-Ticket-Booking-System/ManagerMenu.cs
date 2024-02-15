
using Airport_Ticket_Booking_System.Enums;

namespace Airport_Ticket_Booking_System

{
    public static class ManagerMenu
    {
        public static void Open(List<Flight> flights, List<Booking> bookings, List<Passenger> passengers, FileSystem fileSystem, Manager manager)
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
                            FilterBookings(bookings, manager, flights, passengers);
                            ClearConsoleAndContinue();
                            break;
                        case 2:
                            // Upload Flights from file
                            ImportFlights(flights, fileSystem);
                            ClearConsoleAndContinue();
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

        private static void FilterBookings(List<Booking> bookings, Manager manager, List<Flight> flights, List<Passenger> passengers)
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
            Console.Write("Enter an option (1-8): ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        FilterByFlight(flights, manager);
                        
                        break;
                    case 2:
                        FilterByPrice(manager);
                   
                        break;
                    case 3:
                        FilterByDepartureCountry(manager);
                                           
                        break;
                    case 4:
                        FilterByDestinationCountry(manager);
               
                        break;
                    case 5:
                        FilterByDepartureDate(manager);
                     
                        break;
                    case 6:
                        FilterByDepartureAirport(manager);
                     
                        break;
                     case 7:
                        FilterByArrivalAirport(manager);
                    
                        break;
                    case 8:
                        FilterByPassenger(manager, passengers);
                    
                        break;
                    case 9:                       
                        break;

                    default:
                        Console.WriteLine("Invalid choice option");
                        break;
                }
            }
            else Console.WriteLine("Invalid choice option");
        }


        private static void FilterByPassenger(Manager manager, List<Passenger> passengers)
        {
            Console.WriteLine("Enter Passenger ID:");
            if (int.TryParse(Console.ReadLine(), out int passengerId))
            {
                Passenger selectedPassenger = passengers.FirstOrDefault(p => p.PassengerId == passengerId);
                if (selectedPassenger != null)
                {
                    var filteredBookings = manager.FilterBookingsByPassenger(selectedPassenger);
                    PrintFilteredBookings(filteredBookings);
                }
                else
                {
                    Console.WriteLine("Passenger not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Passenger ID.");
            }
        }

        private static void FilterByArrivalAirport(Manager manager)
        {
            Console.WriteLine("Enter Arrival Airport:");
            string arrivalAirport = Console.ReadLine();
            var filteredBookings = manager.FilterBookingsByArrivalAirport(arrivalAirport);
            PrintFilteredBookings(filteredBookings);
        }

        private static void FilterByDepartureAirport(Manager manager)
        {
            Console.WriteLine("Enter Departure Airport:");
            string departureAirport = Console.ReadLine();
            var filteredBookings = manager.FilterBookingsByDestinationCountry(departureAirport);
            PrintFilteredBookings(filteredBookings);
        }

        private static void FilterByDepartureDate(Manager manager)
        {
            Console.WriteLine("Enter Departure Date (yyyy-MM-dd):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime departureDate))
            {
                var filteredBookings = manager.FilterBookingsByDepartureDate(departureDate);
                PrintFilteredBookings(filteredBookings);
            }
            else
            {
                Console.WriteLine("Invalid Departure Date.");
            }
        }

        private static void FilterByDestinationCountry(Manager manager)
        {
            Console.WriteLine("Enter Destination Country:");
            string departureCountry = Console.ReadLine();
            var filteredBookings = manager.FilterBookingsByDestinationCountry(departureCountry);
            PrintFilteredBookings(filteredBookings);
        }

        private static void FilterByDepartureCountry(Manager manager)
        {
            Console.WriteLine("Enter Departure Country:");
            string departureCountry = Console.ReadLine();
            var filteredBookings = manager.FilterBookingsByDepartureCountry(departureCountry);
            PrintFilteredBookings(filteredBookings);
        }

        private static void FilterByPrice(Manager manager)
        {
            Console.WriteLine("Enter Price:");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Enter Class (1. Economy, 2. Business, 3. First Class):");
                if (Enum.TryParse<FlightClass>(Console.ReadLine(), out FlightClass flightClass))
                {
                    var filteredBookings = manager.FilterBookingsByPrice(price, flightClass);
                    PrintFilteredBookings(filteredBookings);
                }
                else
                {
                    Console.WriteLine("Invalid Class.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Price.");
            }
        }

        private static void FilterByFlight(List<Flight> flights, Manager manager)
        {
            Console.WriteLine("Enter Flight ID: ");
            if (int.TryParse(Console.ReadLine(), out int flightId))
            {
                Flight selectedFlight = flights.FirstOrDefault(f => f.FlightId == flightId);
                if (selectedFlight != null)
                {
                    List<Booking> filteredBookings = manager.FilterBookingsByFlight(selectedFlight);
                    PrintFilteredBookings(filteredBookings);
                }
                else
                {
                    Console.WriteLine($"Flight with ID {flightId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Flight ID.");
            }
        }

        private static void PrintFilteredBookings(List<Booking> filteredBookings)
        {
            foreach (var booking in filteredBookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingID}, Flight: {booking.Flight.FlightId}, Passenger: {booking.Passenger.Name}");
            }
        }

        private static void ImportFlights(List<Flight> flights, FileSystem fileSystem)
        {
            Console.WriteLine("Enter File Path: ");
            string filePath = Console.ReadLine();
            fileSystem.ImportFlightsFromCsv(filePath, flights);
            Console.WriteLine("Flights imported successfully!");

        }

        public static void ClearConsoleAndContinue()
        {
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}