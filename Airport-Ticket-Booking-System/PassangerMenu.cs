using Airport_Ticket_Booking_System.Enums;
using Airport_Ticket_Booking_System.Model;
using System;
using System.Runtime.InteropServices;

namespace Airport_Ticket_Booking_System
{
    public static class PassangerMenu
    {
        public static void Open(List<Flight> flights, List<Booking> bookings, Passenger passenger)
        {
            {
                bool menu = true;

                while (menu)
                {
              
                    Console.WriteLine("***Passanger Interface***");
                    Console.WriteLine("1. Book a Flight");
                    Console.WriteLine("2. Search for a Flight");
                    Console.WriteLine("3. Manage Bookings");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter an option (1-4): ");

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                BookAFlight(flights, passenger, bookings);
                                break;

                            case 2:
                                SelectFlight(flights);

                                break;
                            case 3:
                                ManageBookings(passenger, bookings);
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

        private static void ManageBookings(Passenger passenger, List<Booking> bookings)
        {
            bool menu = true;

            while (menu)
            {
                Console.WriteLine("*** Manage Bookings ***");
                Console.WriteLine("1. Cancel a Booking");
                Console.WriteLine("2. Modify a Booking");
                Console.WriteLine("3. View Personal Bookings");
                Console.WriteLine("4. Go Back");
                Console.Write("Enter an option (1-4): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            CancelBooking(passenger, bookings);
                            break;
                        case 2:
                            ModifyBooking(passenger, bookings);
                            break;
                        case 3:
                            ViewPersonalBookings(passenger);
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

        private static void ViewPersonalBookings(Passenger passenger)
        {        
            Console.WriteLine("Your Bookings:");
            for (int i = 0; i < passenger.Bookings.Count; i++)
            {
                Booking booking = passenger.Bookings[i];
                Console.WriteLine($"{i + 1}. {booking.Flight.DepartureAirport} to {booking.Flight.ArrivalAirport} on {booking.Flight.DepartureDate}, Class: {booking.FlightClass}, Booking Date: {booking.BookingDate}");
            }

        }
        

        private static void ModifyBooking(Passenger passenger, List<Booking> bookings)
        {
            Console.WriteLine("***Modify a Booking***");
            
            ViewPersonalBookings(passenger);
            Console.WriteLine("Enter the index of the Booking to modify:");
            if (int.TryParse(Console.ReadLine(), out int selectedBookingIndex))
            {
                if (selectedBookingIndex >= 0 && selectedBookingIndex < passenger.Bookings.Count)
                {
                    var selectedBooking = passenger.Bookings[selectedBookingIndex];

                    Console.WriteLine("Enter new flight class (1. Economy, 2. Business, 3. First Class):");

                    if (Enum.TryParse<FlightClass>(Console.ReadLine(), out FlightClass newFlightClass))
                    {
                        selectedBooking.ModifyClass(newFlightClass);

                        Console.WriteLine("Booking modified successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid flight class. Please enter a valid class.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }   

        private static void CancelBooking(Passenger passenger, List<Booking> bookings)
        {
            Console.WriteLine("Select a booking to Cancel:");
            ViewPersonalBookings(passenger);
            Console.WriteLine("Enter the Index of the Booking to Cancel: ");
            if (int.TryParse(Console.ReadLine(), out int selectedBookingIndex))
            {
                if (selectedBookingIndex >= 0 && selectedBookingIndex < passenger.Bookings.Count)
                {
                    var selectedBooking = passenger.Bookings[selectedBookingIndex];
                    bookings.Remove(selectedBooking);                                 
                    passenger.CancelBooking(selectedBooking);
                    selectedBooking.CancelBooking(selectedBooking);
                    Console.WriteLine("Booking canceled successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid booking index. Please enter a valid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        private static void BookAFlight(List<Flight> flights, Passenger passenger, List<Booking> bookings)
        {
            Console.WriteLine("*** Book a Flight ***");
            Console.WriteLine("Select a flight to book:");
            SelectFlight(flights);
            Console.WriteLine("Enter the index of the flight you want to book:");
            if (int.TryParse(Console.ReadLine(), out int selectedFlightIndex))
            {
                if (selectedFlightIndex >= 0 && selectedFlightIndex < flights.Count)
                {
                    var selectedFlight = flights[selectedFlightIndex];

                    
                    Console.WriteLine($"You have selected the following flight:");
                    Console.WriteLine($"Flight from {selectedFlight.DepartureAirport} to {selectedFlight.ArrivalAirport} on {selectedFlight.DepartureDate}");

                   

                    Console.WriteLine("Enter flight class (1. Economy, 2. Business, 3. First Class):");
                    if (Enum.TryParse<FlightClass>(Console.ReadLine(), out FlightClass selectedClass))
                    {
                        Booking newBooking = new Booking(passenger, selectedFlight, selectedClass, DateTime.Now);
                        bookings.Add(newBooking);                      
                        
                            
                    }
                    else
                    {
                        Console.WriteLine("Invalid class selection. Please enter a valid class.");
                    }
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
                        SelectByPrice(flights);                        
                        break;
                    case 2:
                        SelectByPriceDepartureCountry(flights);
                        break;
                    case 3:
                        SelectByDestinationCountry(flights);                 
                        break;
                    case 4:
                        SelectByDate(flights);                        
                        break;
                    case 5:
                        SelectByDepartureAirport(flights);                       
                        break;
                    case 6:
                        SelectByArrivalAirport(flights);                        
                        break;
                    case 7:
                        SelectByClass(flights);
                        break;
                    default:
                        Console.WriteLine("Invalid choice option");
                        break;
                }
            }
            else Console.WriteLine("Invalid choice option");
        }

        private static void SelectByClass(List<Flight> flights)
        {
            Console.WriteLine("Enter a class:");
            Console.WriteLine("1. Economy Class");
            Console.WriteLine("2. Business Class");
            Console.WriteLine("3. First Class");
            if (Enum.TryParse<FlightClass>(Console.ReadLine(), out FlightClass selectedClass))
            {
                var filteredFlightsClass = flights.Where(flight => flight.GetAvailableSeats(selectedClass) > 0).ToList();
                Console.WriteLine($"Number of flights after filtering: {filteredFlightsClass.Count}");
                PrintFlights(filteredFlightsClass);

            }
            else
            {
                Console.WriteLine("Invalid class selection. Please enter a valid class.");
            }
        }

        private static void SelectByArrivalAirport(List<Flight> flights)
        {
            Console.WriteLine("Enter Arrival Airport");
            string arrivalAirport = Console.ReadLine();
            var filteredflightsArrivalAirport = flights.Where(flight => flight.ArrivalAirport == arrivalAirport).ToList();
            Console.WriteLine($"Number of flights after filtering: {filteredflightsArrivalAirport.Count}");
            PrintFlights(filteredflightsArrivalAirport);
        }

        private static void SelectByDepartureAirport(List<Flight> flights)
        {
            Console.WriteLine("Enter Departure Airport");
            string departureAirport = Console.ReadLine();
            var filteredFlightsDepartureAirport = flights.Where(flight => flight.DepartureAirport == departureAirport).ToList();
            Console.WriteLine($"Number of flights after filtering: {filteredFlightsDepartureAirport.Count}");
            PrintFlights(filteredFlightsDepartureAirport);
        }

        private static void SelectByDate(List<Flight> flights)
        {
            Console.WriteLine("Enter Departure Date (yyyy-MM-dd): ");
            string departureDateInput = Console.ReadLine();

            if (DateTime.TryParse(departureDateInput, out DateTime parsedDepartureDate))
            {
                var filteredFlightsDepartureDate = flights.Where(flight => flight.DepartureDate.Date == parsedDepartureDate.Date).ToList();
                Console.WriteLine($"Number of flights after filtering: {filteredFlightsDepartureDate.Count}");
                PrintFlights(filteredFlightsDepartureDate);


            }
            else Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
        }

        private static void SelectByDestinationCountry(List<Flight> flights)
        {
            Console.WriteLine("Enter Destination Country:");
            string destinationCountry = Console.ReadLine();
            var filteredFlightsDestinationCountry = flights.Where(flight => flight.DestinationCountry == destinationCountry).ToList();
            Console.WriteLine($"Number of flights after filtering: {filteredFlightsDestinationCountry.Count}");
            PrintFlights(filteredFlightsDestinationCountry);
        }

        private static void SelectByPriceDepartureCountry(List<Flight> flights)
        {
            Console.WriteLine("Enter Departure Country:");
            string departureCountry = Console.ReadLine();
            var filteredFlightsDepartureCountry = flights.Where(flight => flight.DepartureCountry == departureCountry).ToList();
            Console.WriteLine($"Number of flights after filtering: {filteredFlightsDepartureCountry.Count}");
            PrintFlights(filteredFlightsDepartureCountry);
        }

        private static void SelectByPrice(List<Flight> flights)
        {
            Console.WriteLine("Enter price:");

            string priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out decimal price))
            {

                var filteredFlightsPrice = flights.Where(flight => flight.EconomyPrice <= price || flight.BusinessPrice <= price || flight.FirstClassPrice <= price).ToList();

                Console.WriteLine($"Number of flights after filtering: {filteredFlightsPrice.Count}");

                PrintFlights(filteredFlightsPrice);
            }
            else
            {
                Console.WriteLine("Invalid price format. Please enter a valid decimal number.");
            }
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