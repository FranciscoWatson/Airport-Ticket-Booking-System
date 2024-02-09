using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System
{
    public class Booking
    {
        public int BookingID { get; set; }
        public Flight Flight { get; }
        public Passenger Passenger { get; }
        public DateTime BookingDate { get; }
        public string FlightClass { get; }

    }
}
