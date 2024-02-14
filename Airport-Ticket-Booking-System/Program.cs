

namespace Airport_Ticket_Booking_System
{
    public class Program
    {
        static void Main()
        {
            List<Passenger> passengers = new List<Passenger>();
            List<Flight> flights = new List<Flight>();
            List<Booking> bookings = new List<Booking>();
            FileSystem fileSystem = new FileSystem(flights, bookings, passengers);

            bool mainMenu = true;
            
            while (mainMenu)
            {
                Console.WriteLine("***Airport Ticket Booking System***");
                Console.WriteLine("1. Login as Manager");
                Console.WriteLine("2. Login as Passenger");
                Console.WriteLine("3. Exit");
                Console.Write("Enter an option (1-3): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            ManagerMenu.Open(flights, bookings, passengers, fileSystem);
                            break;
                        case 2:
                            Passenger passanger = new Passenger(1, "asd");
                            PassangerMenu.Open(flights, bookings, passanger);                            
                            break;
                        case 3:
                            mainMenu = false;
                            break;  
             
                        default:
                            Console.WriteLine("Invalid choice option");
                            break;
                    }
                }
                else Console.WriteLine("Invalid choice option");
                Manager managerOne = new Manager("Francisco", bookings);
                Passenger passengerOne = new Passenger("Juan");
                passengerOne.BookFlight(flights[0], Enums.FlightClass.Economy, DateTime.Now);

                Console.WriteLine(string.Join(Environment.NewLine, flights[0].bookings.Select(b =>
            $"Booking ID: {b.BookingID}, Passenger Name: {b.Passenger.Name}, Flight Class: {b.FlightClass}, Booking Date: {b.BookingDate}, From: {b.Flight.DepartureAirport}, To: {b.Flight.ArrivalAirport}")));

            }
            Console.WriteLine("Exiting Program...");


           

        }
    }
}

            
