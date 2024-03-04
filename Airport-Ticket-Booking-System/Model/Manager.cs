using Airport_Ticket_Booking_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Model
{
    public class Manager
    {
        public string Name { get; set; }
        public List<Booking> Bookings { get; set; }


        public Manager(string name, List<Booking> bookings)
        {
            Name = name;
            Bookings = bookings;

        }
        public List<Booking> FilterBookingsByFlight(Flight flight)
        {
            return Bookings.Where(b => b.Flight == flight).ToList();
        }
        public List<Booking> FilterBookingsByPrice(decimal price, FlightClass flightClass)
        {
            return Bookings.Where(b => b.FlightClass == flightClass && b.Flight.GetPrice(flightClass) == price).ToList();
        }
        public List<Booking> FilterBookingsByDepartureCountry(string departureCountry)
        {
            return Bookings.Where(b => b.Flight.DepartureCountry == departureCountry).ToList();
        }
        public List<Booking> FilterBookingsByDestinationCountry(string destinationCountry)
        {
            return Bookings.Where(b => b.Flight.DestinationCountry == destinationCountry).ToList();
        }
        public List<Booking> FilterBookingsByDepartureDate(DateTime departureDate)
        {
            return Bookings.Where(b => b.Flight.DepartureDate == departureDate).ToList();
        }
        public List<Booking> FilterBookingsByDepartureAirport(string departureAirport)
        {
            return Bookings.Where(b => b.Flight.DepartureAirport == departureAirport).ToList();
        }
        public List<Booking> FilterBookingsByArrivalAirport(string arrivalAirport)
        {
            return Bookings.Where(b => b.Flight.ArrivalAirport == arrivalAirport).ToList();
        }
        public List<Booking> FilterBookingsByPassenger(Passenger passenger)
        {
            return Bookings.Where(b => b.Passenger == passenger).ToList();
        }

        public void ImportFlightsFromCsv(List<Flight> flights, string filePath, FileSystem fileSystem)
        {

            fileSystem.ImportFlightsFromCsv(filePath, flights);

        }

    }
}
