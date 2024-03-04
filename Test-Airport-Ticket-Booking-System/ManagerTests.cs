using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System;
using Airport_Ticket_Booking_System.Enums;
using Airport_Ticket_Booking_System.Model;
using AutoFixture;
using Moq;
namespace Test_Airport_Ticket_Booking_System
{
    public class ManagerTests
    {
        [Fact]
        public void FilterBookingsByFlightShouldReturnBooking()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var flight = fixture.Create<Flight>();

            fixture.Customize<Booking>(c => c
                .With(b => b.Flight, flight));

            var bookings = fixture.CreateMany<Booking>().ToList();

            var manager = new Manager("test", bookings);

            // Act
            var filteredBooking = manager.FilterBookingsByFlight(flight);

            // Assert
            Assert.NotNull(filteredBooking);
            Assert.Contains(flight, filteredBooking.Select(b => b.Flight));
        }

        [Fact]
        public void FilterBookingsByPriceShouldReturnBooking()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var flightClass = FlightClass.Economy; 
            var price = 100.00m; 

            fixture.Customize<Flight>(c => c
                .With(b => b.EconomyPrice, price));


            var flight = fixture.Create<Flight>();

            fixture.Customize<Booking>(c => c
                .With(b => b.Flight, flight));

            var bookings = fixture.CreateMany<Booking>().ToList();

            var manager = new Manager("test", bookings);


            // Act
            var filteredBooking = manager.FilterBookingsByPrice(price, flightClass);


            // Assert
            Assert.NotNull(filteredBooking);
            Assert.All(filteredBooking, booking =>
            {
                Assert.Equal(price, booking.Flight.EconomyPrice);
                Assert.Equal(flightClass, booking.FlightClass);
            });
        }

        [Fact]
        public void FilterBookingsByDepartureCountryShouldReturnBookings()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var departureCountry = fixture.Create<string>(); 

            fixture.Customize<Flight>(c => c
                .With(f => f.DepartureCountry, departureCountry));


            var flight = fixture.Create<Flight>();

            fixture.Customize<Booking>(c => c
                .With(b => b.Flight, flight));


            var bookings = fixture.CreateMany<Booking>().ToList();

            var manager = new Manager("test", bookings);

            // Act
            var filteredBookings = manager.FilterBookingsByDepartureCountry(departureCountry);

            // Assert
            Assert.NotNull(filteredBookings);
            Assert.True(filteredBookings.All(b => b.Flight.DepartureCountry == departureCountry));
        }

        
        [Fact]
        public void FilterBookingsByDestinationCountryShouldReturnBookings()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var destinationCountry = fixture.Create<string>();

            fixture.Customize<Flight>(c => c
                .With(f => f.DestinationCountry, destinationCountry));


            var flight = fixture.Create<Flight>();

            fixture.Customize<Booking>(c => c
                .With(b => b.Flight, flight));


            var bookings = fixture.CreateMany<Booking>().ToList();

            var manager = new Manager("test", bookings);

            // Act
            var filteredBookings = manager.FilterBookingsByDestinationCountry(destinationCountry);

            // Assert
            Assert.NotNull(filteredBookings);
            Assert.True(filteredBookings.All(b => b.Flight.DestinationCountry == destinationCountry));
        }
       

        [Fact]
        public void FilterBookingsByDepartureDateShouldReturnBookings()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var departureDate = fixture.Create<DateTime>();

            fixture.Customize<Flight>(c => c
                .With(f => f.DepartureDate, departureDate));


            var flight = fixture.Create<Flight>();

            fixture.Customize<Booking>(c => c
                .With(b => b.Flight, flight));


            var bookings = fixture.CreateMany<Booking>().ToList();

            var manager = new Manager("test", bookings);

            // Act
            var filteredBookings = manager.FilterBookingsByDepartureDate(departureDate);

            // Assert
            Assert.NotNull(filteredBookings);
            Assert.True(filteredBookings.All(b => b.Flight.DepartureDate == departureDate));
        }

        

        [Fact]
        public void FilterBookingsByDepartureAirportShouldReturnBookings()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var departureAirport = fixture.Create<string>();

            fixture.Customize<Flight>(c => c
                .With(f => f.DepartureAirport, departureAirport));


            var flight = fixture.Create<Flight>();

            fixture.Customize<Booking>(c => c
                .With(b => b.Flight, flight));


            var bookings = fixture.CreateMany<Booking>().ToList();

            var manager = new Manager("test", bookings);

            // Act
            var filteredBookings = manager.FilterBookingsByDepartureAirport(departureAirport);

            // Assert   
            Assert.NotNull(filteredBookings);
            Assert.True(filteredBookings.All(b => b.Flight.DepartureAirport == departureAirport));
        }

        

        [Fact]
        public void FilterBookingsByArrivalAirportShouldReturnBookings()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var arrivalAirport = fixture.Create<string>();

            fixture.Customize<Flight>(c => c
                .With(f => f.ArrivalAirport, arrivalAirport));


            var flight = fixture.Create<Flight>();

            fixture.Customize<Booking>(c => c
                .With(b => b.Flight, flight));


            var bookings = fixture.CreateMany<Booking>().ToList();

            var manager = new Manager("test", bookings);

            // Act
            var filteredBookings = manager.FilterBookingsByArrivalAirport(arrivalAirport);

            // Assert   
            Assert.NotNull(filteredBookings);
            Assert.True(filteredBookings.All(b => b.Flight.ArrivalAirport == arrivalAirport));
        }

        [Fact]
        public void FilterBookingsByPassengerShouldReturnBookings()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var passenger = fixture.Create<Passenger>();

            fixture.Customize<Booking>(c => c
                .With(b => b.Passenger, passenger));

            var bookings = fixture.CreateMany<Booking>().ToList();

            var manager = new Manager("test", bookings);

            // Act
            var filteredBooking = manager.FilterBookingsByPassenger(passenger);

            // Assert
            Assert.NotNull(filteredBooking);
            Assert.Contains(passenger, filteredBooking.Select(b => b.Passenger));
        }

        [Fact]
        public void ImportFlightsFromCsv_ShouldInvokeFileSystemImportMethod()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var flights = fixture.Create<List<Flight>>();
            var filePath = "TestFilePath";
            var bookings = fixture.Create<List<Booking>>();
            var fileSystemMock = new Mock<FileSystem>();

            fileSystemMock.Setup(fs => fs.ImportFlightsFromCsv(filePath, flights));

            var manager = new Manager("test", bookings); 

            // Act
            manager.ImportFlightsFromCsv(flights, filePath, fileSystemMock.Object);

            // Assert
            fileSystemMock.Verify(fs => fs.ImportFlightsFromCsv(filePath, flights), Times.Once);
        }
    }
}
