using Airport_Ticket_Booking_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Airport_Ticket_Booking_System.Model
{
    public class Flight
    {


        public int FlightId { get; set; }

        [Required(ErrorMessage = "The Economy Price is required")]
        public decimal EconomyPrice { get; set; }

        [Required(ErrorMessage = "The Business Price is required.")]
        public decimal BusinessPrice { get; set; }

        [Required(ErrorMessage = "The First Class price is required.")]
        public decimal FirstClassPrice { get; set; }

        [Required(ErrorMessage = "The Departure Country is required.")]
        public string DepartureCountry { get; set; }

        [Required(ErrorMessage = "The Destination Country is required.")]
        public string DestinationCountry { get; set; }

        [Required(ErrorMessage = "The Departure Date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }
        [Required(ErrorMessage = "The Departure Airport is required.")]
        public string DepartureAirport { get; set; }

        [Required(ErrorMessage = "The Arrival Airport is required.")]
        public string ArrivalAirport { get; set; }

        [Required(ErrorMessage = "Number of Economy Seats is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int NumberOfEconomySeats { get; set; }

        [Required(ErrorMessage = "Number of Business Seats is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int NumberOfBusinessSeats { get; set; }

        [Required(ErrorMessage = "Number of First Class Seats is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int NumberOfFirstClassSeats { get; set; }

        public List<Booking> bookings { get; set; } = new List<Booking>();

        public Flight()
        {
            
        }
        public Flight(int flightId, decimal economyPrice, decimal businessPrice, decimal firstClassPrice, string departureCountry, string destinationCountry, DateTime departureDate, string departureAirport, string arrivalAirport, int numberOfEconomySeats, int numberOfBusinessSeats, int numberOfFirstClassSeats)
        {
            FlightId = flightId;
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

        public int GetAvailableSeats(FlightClass flightClass)
        {
            return flightClass switch
            {
                FlightClass.Economy => NumberOfEconomySeats,
                FlightClass.Business => NumberOfBusinessSeats,
                FlightClass.FirstClass => NumberOfFirstClassSeats,
                _ => throw new InvalidOperationException("Invalid Flight Class"),
            };
        }

        virtual public void CancelBooking(Booking selectedBooking)
        {
            bookings.Remove(selectedBooking);
        }

        virtual public void ModifyClass(Booking booking, FlightClass newFlightClass)
        {
            if (bookings.Contains(booking))
            {
                int currentSeats = GetAvailableSeats(booking.FlightClass);
                int newSeats = GetAvailableSeats(newFlightClass);

                if (newSeats > 0)
                {

                    bookings.Remove(booking);


                    booking.FlightClass = newFlightClass;


                    bookings.Add(booking);
                    newSeats--;
                    currentSeats++;
                    Console.WriteLine("Booking class modified successfully!");
                }
                else
                {
                    Console.WriteLine($"No seats available in {newFlightClass} class.");
                }
            }
            else
            {
                Console.WriteLine("The selected booking does not belong to this flight.");
            }
        }
        public static void DisplayValidationDetails()
        {
            Type flightType = typeof(Flight);
            PropertyInfo[] properties = flightType.GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine($"* {property.Name}:");

                var attributes = property.GetCustomAttributes<ValidationAttribute>(true);

                foreach (var attribute in attributes)
                {
                    Console.WriteLine($"\t- Type: {property.PropertyType.Name}");
                    Console.WriteLine($"\t- Constraint: {GetValidationDetails(attribute)}");
                }

                Console.WriteLine();
            }
        }

        private static string GetValidationDetails(ValidationAttribute attribute)
        {
            return attribute switch
            {
                RequiredAttribute requiredAttribute => "Required",
                RangeAttribute rangeAttribute => $"Allowed Range ({rangeAttribute.Minimum} → {rangeAttribute.Maximum})",
                _ => "Unknown Constraint",
            };
        }
    }
}
