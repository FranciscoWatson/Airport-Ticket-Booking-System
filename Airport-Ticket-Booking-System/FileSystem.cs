using Airport_Ticket_Booking_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Exceptions;

namespace Airport_Ticket_Booking_System
{
    public class FileSystem
    {
        public List<Flight> flights {  get; set; }

        public FileSystem(string filePath)
        {
            flights = new List<Flight>();
            ImportFlightsFromCsv(filePath);
        }

        public void ImportFlightsFromCsv(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Skip the header line
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        decimal economyPrice = decimal.Parse(values[0]);
                        decimal businessPrice = decimal.Parse(values[1]);
                        decimal firstClassPrice = decimal.Parse(values[2]);
                        string departureCountry = values[3];
                        string destinationCountry = values[4];
                        DateTime departureDate = DateTime.ParseExact(values[5], "M/d/yyyy", CultureInfo.InvariantCulture);
                        string departureAirport = values[6];
                        string arrivalAirport = values[7];
                        int.TryParse(values[8], out int numberOfEconomySeats);
                        int.TryParse(values[9], out int numberOfBusinessSeats);
                        int.TryParse(values[10], out int numberOfFirstClassSeats);
                        Flight flight = new Flight(economyPrice, businessPrice, firstClassPrice, departureCountry, destinationCountry, departureDate, departureAirport, arrivalAirport, numberOfEconomySeats, numberOfBusinessSeats, numberOfFirstClassSeats);                      
                        flights.Add(flight);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found, invalid format, etc.)
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }
        }







    } 
}
