using Airport_Ticket_Booking_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Exceptions;

namespace Airport_Ticket_Booking_System
{
    internal class FileManager
    {
        public void ImportFlightsFromCsv(List<Flight> flights, string filePath)
        {
            try
            {
                List<Flight> importedFlights = new List<Flight>();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        string[] values = line!.Split(',');

                        
                        decimal economyPrice = decimal.Parse(values[0].Trim());
                        decimal businessPrice = decimal.Parse(values[1].Trim());
                        decimal firstClassPrice = decimal.Parse(values[2].Trim());
                        string departureCountry = values[3].Trim();
                        string destinationCountry = values[4].Trim();
                        DateTime departureDate = DateTime.Parse(values[5].Trim());
                        string departureAirport = values[6].Trim();
                        string arrivalAirport = values[7].Trim();
                        int numberOfEconomySeats = int.Parse(values[8].Trim());
                        int numberOfBusinessSeats = int.Parse(values[9].Trim());
                        int numberOfFirstClassSeats = int.Parse(values[10].Trim());

         
                        Flight flight = new Flight(
                            economyPrice, businessPrice, firstClassPrice,
                            departureCountry, destinationCountry, departureDate,
                            departureAirport, arrivalAirport, numberOfEconomySeats,
                            numberOfBusinessSeats, numberOfFirstClassSeats
                        );

                        flights.Add(flight);
                        
                     }
                }

                
            }
            catch (Exception ex)
            {
                throw new ErrorImportingCsvException(ex.Message);
            }


        }
    }
}
