using Airport_Ticket_Booking_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Enums;

namespace Airport_Ticket_Booking_System.Model
{
    public class Booking
    {
        private static int lastBookingId = 0;
        public int BookingID { get; set; }
        public Flight Flight { get; }
        public Passenger Passenger { get; }
        public DateTime BookingDate { get; }
        public FlightClass FlightClass { get; set; }

        public Booking(int bookingId, Passenger passenger, Flight flight, FlightClass flightClass, DateTime bookingDate)
        {
            BookingID = bookingId;
            Passenger = passenger;
            Flight = flight;
            FlightClass = flightClass;
            BookingDate = bookingDate;
        }
        public Booking(Passenger passenger, Flight flight, FlightClass flightClass, DateTime bookingDate)
        {
            BookingID = GetNextBookingId();
            Passenger = passenger;
            Flight = flight;
            FlightClass = flightClass;
            BookingDate = bookingDate;
            Flight.BookFlight(this);
            Passenger.BookFlight(this);
        }

        private static int GetNextBookingId()
        {
            return ++lastBookingId;
        }
        public static void SetLastBookingId(int value)
        {
            lastBookingId = value;
        }

        public void CancelBooking(Booking selectedBooking)
        {
            Flight.CancelBooking(selectedBooking);
        }

        public void ModifyClass(FlightClass newFlightClass)
        {

            //      FlightClass = newFlightClass;
            Flight.ModifyClass(this, newFlightClass);
        }
    }
}
