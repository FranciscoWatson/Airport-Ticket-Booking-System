using Airport_Ticket_Booking_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Exceptions;
using System.IO;
using System.Reflection;
using Airport_Ticket_Booking_System.Enums;
using Airport_Ticket_Booking_System.Model;
using System.ComponentModel.DataAnnotations;

namespace Airport_Ticket_Booking_System
{
    public class FileSystem
    {
        
        public FileSystem(List<Flight> flights, List<Booking> bookings, List<Passenger> passengers)
        {

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string flightCsvPath = Path.Combine(basePath, "..", "..", "..", "Data", "flights.csv");
            ImportFlightsFromCsv(flightCsvPath, flights);
            string passengerCsvPath = Path.Combine(basePath, "..", "..", "..", "Data", "passengers.csv");
            ImportPassengersFromCsv(passengerCsvPath, passengers);
            string bookingCsvPath = Path.Combine(basePath, "..", "..", "..", "Data", "bookings.csv");
            ImportBookingsFromCsv(bookingCsvPath, bookings, passengers, flights);
  
        }
        public void ImportBookingsFromCsv(string filePath, List<Booking> bookings, List<Passenger> passengers, List<Flight> flights)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); 

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        int bookingId = int.Parse(values[0]);
                        int passengerId = int.Parse(values[1]);
                        int flightId = int.Parse(values[2]);
                        FlightClass flightClass = Enum.Parse<FlightClass>(values[3]);
                        DateTime bookingDate = DateTime.ParseExact(values[4], "M/d/yyyy", CultureInfo.InvariantCulture);

                        
                        Passenger passenger = passengers.FirstOrDefault(p => p.PassengerId == passengerId);
                        Flight flight = flights.FirstOrDefault(f => f.FlightId == flightId);

                        if (passenger != null && flight != null)
                        {
                            Booking.SetLastBookingId(bookingId - 1); 
                            Booking booking = new Booking(bookingId, passenger, flight, flightClass, bookingDate);
                            bookings.Add(booking);
                            passenger.Bookings.Add(booking);
                            flight.bookings.Add(booking);
                        }
                        else
                        {
                            Console.WriteLine($"Error creating booking: Passenger with ID {passengerId} or Flight with ID {flightId} not found.");
                        }
                    }
                }
                Console.WriteLine("Bookings Imported Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file for bookings: {ex.Message}");
            }
        }
        public void ImportPassengersFromCsv(string filePath, List<Passenger> passengers)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');


                        int passangerId = int.Parse(values[0]);
                        string name = values[1];

                        Passenger.SetLastPassengerId(passangerId - 1);

                        Passenger passenger = new Passenger(passangerId, name);
                        passengers.Add(passenger);
                    }
                }
                Console.WriteLine("Passengers Imported Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file for passengers: {ex.Message}");
            }
        }


        public void ImportFlightsFromCsv(string filePath, List<Flight> flights)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        int flightId = int.Parse(values[0]);
                        decimal economyPrice = decimal.Parse(values[1]);
                        decimal businessPrice = decimal.Parse(values[2]);
                        decimal firstClassPrice = decimal.Parse(values[3]);
                        string departureCountry = values[4];
                        string destinationCountry = values[5];
                        DateTime departureDate = DateTime.ParseExact(values[6], "M/d/yyyy", CultureInfo.InvariantCulture);
                        string departureAirport = values[7];
                        string arrivalAirport = values[8];
                        int.TryParse(values[9], out int numberOfEconomySeats);
                        int.TryParse(values[10], out int numberOfBusinessSeats);
                        int.TryParse(values[11], out int numberOfFirstClassSeats);
                        Flight.SetLastFlightId(flightId - 1);
                        Flight flight = new Flight(flightId, economyPrice, businessPrice, firstClassPrice, departureCountry, destinationCountry, departureDate, departureAirport, arrivalAirport, numberOfEconomySeats, numberOfBusinessSeats, numberOfFirstClassSeats);
                        flights.Add(flight);
                    }
                }
                Console.WriteLine("Flights Imported Successfully");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error reading CSV file: {ex.Message}");
                Flight.DisplayValidationDetails();
            }
        }
    } 
}
