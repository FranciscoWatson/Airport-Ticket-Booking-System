

namespace Airport_Ticket_Booking_System
{
    public class Program
    {
        static void Main()
        {
            FileSystem fileSystem = new FileSystem(@"C:\Users\Francisco\Desktop\test\test.csv");
            Manager managerOne = new Manager("Francisco", fileSystem);
            Passenger passengerOne = new Passenger(1, "Juan");
            passengerOne.BookFlight(fileSystem.flights[0], Enums.FlightClass.Economy, DateTime.Now);
            
            Console.WriteLine(string.Join(Environment.NewLine, fileSystem.flights[0].bookings.Select(b =>
        $"Booking ID: {b.BookingID}, Passenger Name: {b.Passenger.Name}, Flight Class: {b.FlightClass}, Booking Date: {b.BookingDate}")));
        }
    }
}

            
