

namespace Airport_Ticket_Booking_System
{
    public class Program
    {
        static void Main()
        {
            bool mainMenu = true;
            
            while (mainMenu)
            {
                FileSystem fileSystem = new FileSystem(@"C:\Users\Francisco\Desktop\test\test.csv");
                Console.WriteLine("***Airport Ticket Booking System***");
                Console.WriteLine("1. Enter as Manager");
                Console.WriteLine("2. Enter as Passanger");
                Console.WriteLine("3. Exit");
                Console.Write("Enter an option (1-3): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            ManagerMenu.Open(fileSystem);
                            break;
                        case 2:
                            Console.WriteLine("\n");
                            PassangerMenu.Open(fileSystem);
                            
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
                Manager managerOne = new Manager("Francisco", fileSystem);
                Passenger passengerOne = new Passenger(1, "Juan");
                passengerOne.BookFlight(fileSystem.flights[0], Enums.FlightClass.Economy, DateTime.Now);

                Console.WriteLine(string.Join(Environment.NewLine, fileSystem.flights[0].bookings.Select(b =>
            $"Booking ID: {b.BookingID}, Passenger Name: {b.Passenger.Name}, Flight Class: {b.FlightClass}, Booking Date: {b.BookingDate}")));

            }
            Console.WriteLine("Exiting Program...");


           

        }
    }
}

            
