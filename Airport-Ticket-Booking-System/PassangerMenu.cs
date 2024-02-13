using Airport_Ticket_Booking_System.Enums;
using System.Runtime.InteropServices;

namespace Airport_Ticket_Booking_System
{
    public static class PassangerMenu
    {
        public static void Open(List<Flight> flights, List<Booking> bookings, List<Passenger> passengers)
        {
            {
                bool menu = true;

                while (menu)
                {
              
                    Console.WriteLine("***Passanger Interface***");
                    Console.WriteLine("1. Book a Flight");
                    Console.WriteLine("2. Search a Flight");
                    Console.WriteLine("3. Manage Bookings");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter an option (1-4): ");

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                  
                                break;
                            case 2:
                                SelectFlight(flights);

                                break;
                            case 3:
                                // Manage Your Bookings
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
        }

        private static void SelectFlight(List<Flight> flights)
        {

            Console.WriteLine("***Select Filter");
            Console.WriteLine("1. Flight Price");
            Console.WriteLine("2. Departure Country");
            Console.WriteLine("3. Destination Country");
            Console.WriteLine("4. Departure Date");
            Console.WriteLine("5. Departure Airport");
            Console.WriteLine("6. Arrival Airport");
            Console.Write("Enter an option (1-6): ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter price:");

                        string priceInput = Console.ReadLine();
                        if (decimal.TryParse(priceInput, out decimal price))
                        {
                            Console.WriteLine($"Searching for flights with price less than or equal to {price}");

                            var allFlightsCount = flights.Count;
                            Console.WriteLine($"Total number of flights before filtering: {allFlightsCount}");

                            var filteredFlightsPrice = flights.Where(flight => flight.EconomyPrice <= price || flight.BusinessPrice <= price || flight.FirstClassPrice <= price).ToList();


                            Console.WriteLine($"Number of flights after filtering: {filteredFlightsPrice.Count}");

                            PrintFlights(filteredFlightsPrice);
                            if (filteredFlightsPrice.Count > 0)
                            {
                                Console.WriteLine("Enter the index of the flight you want to book:");
                                if (int.TryParse(Console.ReadLine(), out int selectedFlightIndex))
                                {
                                    if (selectedFlightIndex >= 0 && selectedFlightIndex < filteredFlightsPrice.Count)
                                    {
                                        var selectedFlight = filteredFlightsPrice[selectedFlightIndex];

                                        Console.WriteLine($"You have selected the following flight:");
                                        Console.WriteLine($"Flight from {selectedFlight.DepartureAirport} to {selectedFlight.ArrivalAirport} on {selectedFlight.DepartureDate}");

                                        // Proceed with booking
                                        Book(selectedFlight);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid flight index. Please enter a valid index.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No flights available matching the criteria.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid price format. Please enter a valid decimal number.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Departure Country:");
                        string departureCountry = Console.ReadLine();
                        var filteredFlightsDepartureCountry = flights.Where(flight => flight.DepartureCountry == departureCountry).ToList();
                        break;
                    case 3:
                        Console.WriteLine("Enter Destination Country:");
                        string destinationCountry = Console.ReadLine();
                        var filteredFlightsDestinationCountry = flights.Where(flight => flight.DestinationCountry == destinationCountry).ToList();
                        break;
                    case 4:
                        Console.WriteLine("Enter Departure Date (yyyy-MM-dd): ");
                        string departureDateInput = Console.ReadLine();

                        if (DateTime.TryParse(departureDateInput, out DateTime parsedDepartureDate))
                        {
                            var filteredFlightsDepartureDate = flights.Where(flight => flight.DepartureDate.Date == parsedDepartureDate.Date).ToList();
                        }
                        else Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
                        break;
                    case 5: 
                        Console.WriteLine("Enter Departure Airport");
                        string departureAirport = Console.ReadLine();
                        var filteredFlightsDepartureAirport = flights.Where(flight => flight.DepartureAirport == departureAirport).ToList();
                        break;
                    case 6:
                        Console.WriteLine("Enter Arrival Airport");
                        string arrivalAirport = Console.ReadLine();
                        var filteredflightsArrivalAirport = flights.Where(flight => flight.ArrivalAirport == arrivalAirport).ToList();
                        break;
                    case 7:
                        Console.WriteLine("Enter a class:");
                        Console.WriteLine("1. Economy Class");
                        Console.WriteLine("2. Business Class");
                        Console.WriteLine("3. First Class");
                        if (Enum.TryParse<FlightClass>(Console.ReadLine(), out FlightClass selectedClass))
                        {
                            var filteredFlightsClass = flights.Where(flight => flight.GetAvailableSeats(selectedClass) > 0).ToList();
                        }
                        else
                        {
                            Console.WriteLine("Invalid class selection. Please enter a valid class.");
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid choice option");
                        break;
                }
            }
            else Console.WriteLine("Invalid choice option");
        }
        private static void PrintFlights(List<Flight> flightsToPrint)
        {
            if (flightsToPrint.Any())
            {
                Console.WriteLine("Filtered Flights:");
                foreach (var flight in flightsToPrint)
                {
                    Console.WriteLine($"Flight from {flight.DepartureAirport} to {flight.ArrivalAirport} on {flight.DepartureDate}");
                    
                }
            }
            else
            {
                Console.WriteLine("No flights found matching the criteria.");
            }

        }
    }
}