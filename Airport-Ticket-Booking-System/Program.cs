

using Airport_Ticket_Booking_System.Model;

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
                Console.Clear();
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
                            Manager manager = new Manager("Francisco", bookings);
                            ManagerMenu.Open(flights, bookings, passengers, fileSystem, manager);
                            break;
                        case 2:
                            Passenger passanger = SelectPassenger(passengers);
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
            }
            Console.WriteLine("Exiting Program...");


           

        }

        private static Passenger SelectPassenger(List<Passenger> passengers)
        {
            Console.WriteLine("Available Passengers:");

            var numberedPassengers = passengers.Select((passenger, index) => $"{index + 1}. {passenger.Name}");
            Console.WriteLine(string.Join(Environment.NewLine, numberedPassengers));

            int selectedNumber;
            while (true)
            {
                Console.Write("Enter the number corresponding to the passenger you want to select: ");
                if (int.TryParse(Console.ReadLine(), out selectedNumber) && selectedNumber >= 1 && selectedNumber <= passengers.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            return passengers[selectedNumber - 1];
        }
    }
}

            
