using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System
{
    public class Flight
    {      
        public enum FlightClass
        {
            Economy,
            Business,
            FirstClass
        }
        public decimal EconomyPrice { get; set; }
        public decimal BusinessPrice { get; set; }
        public decimal FirstClassPrice { get; set; }
        public string DepartureCountry { get; set; }
        public string DestinationCountry { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public int NumberOfEconomySeats { get; set; }
        public int NumberOfBusinessSeats { get; set; }
        public int NumberOfFirstClassSeats { get; set; }

        public Flight(decimal economyPrice, decimal businessPrice, decimal firstClassPrice, string departureCountry, string destinationCountry, DateTime departureDate, string departureAirport, string arrivalAirport, int numberOfEconomySeats, int numberOfBusinessSeats, int numberOfFirstClassSeats)
        {
            EconomyPrice = economyPrice;
            BusinessPrice = businessPrice;
            FirstClassPrice = firstClassPrice;
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureDate = departureDate;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            NumberOfEconomySeats = numberOfEconomySeats;
            NumberOfBusinessSeats = numberOfBusinessSeats;
            NumberOfFirstClassSeats = numberOfFirstClassSeats;
        }
    }
}
