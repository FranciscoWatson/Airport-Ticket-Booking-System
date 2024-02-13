namespace Airport_Ticket_Booking_System
{
    public static class PassangerMenu
    {
        public static void Open(List<Flight> flights, List<Booking> bookings, List<Passenger> passengers)
        {
            {
                bool menu = true;

                while (menu)
                {
                    Console.Clear();
                    Console.WriteLine("***Passanger Interface***");
                    Console.WriteLine("1. Select a Flight");
                    Console.WriteLine("2. Enter as Passanger");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter an option (1-3): ");

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                //Select a Flight                            
                                break;
                            case 2:
                                // Search Available Flights

                                break;
                            case 3:
                                // Manage Your Bookings
                                break;
                            case 4:
                                menu = false;
                                break;

                            default:
                                Console.WriteLine("Invalid choice option");
                                break;
                        }
                    }
                    else Console.WriteLine("Invalid choice option");
                }
            }
        }
    }
}