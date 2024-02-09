using System;
using System.Collections.Generic;
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

    }
}
