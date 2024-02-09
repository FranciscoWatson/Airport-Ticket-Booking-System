using Airport_Ticket_Booking_System.Exceptions;
using Airport_Ticket_Booking_System.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public int Name { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public Passenger(int passengerId, int name)
        {
            PassengerId = passengerId;
            Name = name;
        }

        public void BookFlight(Flight flight, FlightClass flightClass, DateTime bookingDate) 
        {
            try
            {
                Booking newBooking = new Booking(this, flight, flightClass, bookingDate);
                Bookings.Add(newBooking);
            }catch(FlightFullException ex)
            {
                Console.WriteLine($"An error occurred during booking. {ex.Message}");
            }
            
        }
    }
}
