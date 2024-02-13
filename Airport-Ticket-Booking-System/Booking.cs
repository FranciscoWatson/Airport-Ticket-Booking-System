using Airport_Ticket_Booking_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Enums;

namespace Airport_Ticket_Booking_System
{
    public class Booking
    {
        public int BookingID { get; set; }
        public Flight Flight { get; }
        public Passenger Passenger { get; }
        public DateTime BookingDate { get; }
        public FlightClass FlightClass { get; }

        public Booking(Passenger passenger, Flight flight, FlightClass flightClass, DateTime bookingDate)
        {
      
            Passenger = passenger;
            Flight = flight;
            FlightClass = flightClass;
            BookingDate = bookingDate;
            Flight.BookFlight(this);
                       
            
        }
    }
}
