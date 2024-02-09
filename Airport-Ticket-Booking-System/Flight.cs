using Airport_Ticket_Booking_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Enums;

namespace Airport_Ticket_Booking_System
{
    public class Flight
    {      
        
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

        public List<Booking> bookings { get; set; } = new List<Booking>();

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

        public void BookFlight(Booking booking, FlightClass flightClass)
        {
            switch (flightClass)
            {
                case FlightClass.Economy:
                    if (NumberOfEconomySeats > 0)
                    {
                        bookings.Add(booking);
                        NumberOfEconomySeats--;
                    }
                    else throw new InvalidOperationException("No seats available in Economy class");


                    break;
                case FlightClass.Business:
                    if (NumberOfBusinessSeats > 0)
                    {
                        bookings.Add(booking);
                        NumberOfBusinessSeats--;
                    }
                    else throw new InvalidOperationException("No seats available in Business class");

                    break;
                case FlightClass.FirstClass:
                    if (NumberOfFirstClassSeats > 0)
                    {
                        bookings.Add(booking);
                        NumberOfFirstClassSeats--;
                    }
                    else throw new InvalidOperationException("No seats available in First Class");

                    break;
                default:
                    throw new InvalidOperationException("Invalid flight class");
            }
        }

        public void BookFlight(Booking booking)
        {
            switch (booking.FlightClass)
            {
                case FlightClass.Economy:
                    if (NumberOfEconomySeats > 0)
                    {
                        bookings.Add(booking);
                        NumberOfEconomySeats--;
                    }
                    else throw new FlightFullException("No seats available in Economy class");


                    break;
                case FlightClass.Business:
                    if (NumberOfBusinessSeats > 0)
                    {
                        bookings.Add(booking);
                        NumberOfBusinessSeats--;
                    }
                    else throw new FlightFullException("No seats available in Business class");

                    break;
                case FlightClass.FirstClass:
                    if (NumberOfFirstClassSeats > 0)
                    {
                        bookings.Add(booking);
                        NumberOfFirstClassSeats--;
                    }
                    else throw new FlightFullException("No seats available in FirstClass class");

                    break;
                default:
                    throw new InvalidOperationException("Invalid Flight Class");
            }
        }
        public decimal GetPrice(FlightClass flightClass)
        {
            switch (flightClass)
            {
                case FlightClass.Economy:
                    return EconomyPrice;
                case FlightClass.Business:
                    return BusinessPrice;
                case FlightClass.FirstClass:
                    return FirstClassPrice;
                default:
                    throw new InvalidOperationException("Invalid Flight Class");
            }
        }
    }

}
