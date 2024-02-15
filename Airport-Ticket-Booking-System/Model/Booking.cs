﻿using Airport_Ticket_Booking_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Airport_Ticket_Booking_System.Model
{
    public class Booking
    {
        private static int lastBookingId = 0;
        public int BookingID { get; set; }

        [Required(ErrorMessage = "Passenger is required.")]
        public Passenger Passenger { get; }

        [Required(ErrorMessage = "Flight is required.")]
        public Flight Flight { get; }

        [Required(ErrorMessage = "Flight Class is required.")]
        public FlightClass FlightClass { get; set; }

        [Required(ErrorMessage = "Booking Date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; }

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
