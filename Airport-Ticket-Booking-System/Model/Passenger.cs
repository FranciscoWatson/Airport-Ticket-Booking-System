using Airport_Ticket_Booking_System.Exceptions;
using Airport_Ticket_Booking_System.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Airport_Ticket_Booking_System.Model
{
    public class Passenger
    {
        private static int lastPassengerId = 0;

        public int PassengerId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public Passenger(string name)
        {
            PassengerId = GetNextPassengerId();
            Name = name;
        }
        public Passenger(int passengerId, string name)
        {
            PassengerId = passengerId;
            Name = name;
        }

        public void BookFlight(Booking newBooking)
        {
            try
            {
                Bookings.Add(newBooking);
            }
            catch (FlightFullException ex)
            {
                Console.WriteLine($"An error occurred during booking. {ex.Message}");
            }

        }
        public static void SetLastPassengerId(int value)
        {
            lastPassengerId = value;
        }
        private static int GetNextPassengerId()
        {
            return ++lastPassengerId;
        }

        public void CancelBooking(Booking selectedBooking)
        {
            Bookings.Remove(selectedBooking);
        }
    }
}
