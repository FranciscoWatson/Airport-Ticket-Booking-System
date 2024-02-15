using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Exceptions
{
    public class FlightFullException : Exception
    {
        public FlightFullException(string message) : base(message) { }

    }
}
