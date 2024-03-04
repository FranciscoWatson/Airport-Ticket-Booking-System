using Airport_Ticket_Booking_System;
using Airport_Ticket_Booking_System.Enums;
using Airport_Ticket_Booking_System.Exceptions;
using Airport_Ticket_Booking_System.Model;
using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Airport_Ticket_Booking_System
{
    public class FlightTests
    {
        [Theory]
        [InlineData(FlightClass.Economy)]
        [InlineData(FlightClass.Business)]
        [InlineData(FlightClass.FirstClass)]
        public void BookAFlightWithEmptySeatsTest(FlightClass flightClass) 
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var newBooking = fixture.Build<Booking>()
                                    .With(b => b.FlightClass, flightClass)
                                    .Create();

            var numberOfSeats = fixture.Create<int>();

            var flight = fixture.Build<Flight>()
                    .With(f => f.NumberOfEconomySeats, numberOfSeats)
                    .With(f => f.NumberOfBusinessSeats, numberOfSeats)
                    .With(f => f.NumberOfFirstClassSeats, numberOfSeats)
                    .Create();

            

            // Act
            flight.BookFlight(newBooking);


            // Assert
            switch (flightClass)
            {
                case FlightClass.Economy:
                    Assert.Equal(numberOfSeats - 1, flight.NumberOfEconomySeats);
                    break;
                case FlightClass.Business:
                    Assert.Equal(numberOfSeats - 1, flight.NumberOfBusinessSeats);
                    break;
                case FlightClass.FirstClass:
                    Assert.Equal(numberOfSeats - 1, flight.NumberOfFirstClassSeats);
                    break;
            }

            Assert.Contains(newBooking, flight.bookings);
        }

        [Theory]
        [InlineData(FlightClass.Economy)]
        [InlineData(FlightClass.Business)]
        [InlineData(FlightClass.FirstClass)]
        public void BookAFlightWithNoSeatsAvailableTest(FlightClass flightClass)
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var newBooking = fixture.Build<Booking>()
                                    .With(b => b.FlightClass, flightClass)
                                    .Create();

            var numberOfSeats = 0;

            var flight = fixture.Build<Flight>()
                    .With(f => f.NumberOfEconomySeats, numberOfSeats)
                    .With(f => f.NumberOfBusinessSeats, numberOfSeats)
                    .With(f => f.NumberOfFirstClassSeats, numberOfSeats)
                    .Create();



           
            // Act & Assert
            Assert.Throws<FlightFullException>(() => flight.BookFlight(newBooking));

        }

        [Theory]
        [InlineData(FlightClass.Business)]
        [InlineData(FlightClass.Economy)]
        [InlineData(FlightClass.FirstClass)]
        public void GetPriceTest(FlightClass flightClass)
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var businessPrice = fixture.Create<decimal>();
            var economyPrice = fixture.Create<decimal>();
            var firstClassPrice = fixture.Create<decimal>();

            var flight = fixture.Build<Flight>()
                .With(f => f.BusinessPrice, businessPrice)
                .With(f => f.EconomyPrice, economyPrice)
                .With(f => f.FirstClassPrice, firstClassPrice)
                .Create();

            var expectedPrice = flightClass switch
            {
                FlightClass.Economy => economyPrice,
                FlightClass.Business => businessPrice,
                FlightClass.FirstClass => firstClassPrice
            };

            // Act
            var price = flight.GetPrice(flightClass);

            // Assert
            Assert.Equal(expectedPrice, price);
        }

        

        [Theory]
        [InlineData(FlightClass.Business)]
        [InlineData(FlightClass.Economy)]
        [InlineData(FlightClass.FirstClass)]
        public void GetAvailableSeatsTest(FlightClass flightClass)
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var businessSeats = fixture.Create<int>();
            var economySeats = fixture.Create<int>();
            var firstClassSeats = fixture.Create<int>();

            var flight = fixture.Build<Flight>()
                .With(f => f.NumberOfBusinessSeats, businessSeats)
                .With(f => f.NumberOfEconomySeats, economySeats)
                .With(f => f.NumberOfFirstClassSeats, firstClassSeats)
                .Create();

            var expectedSeats = flightClass switch
            {
                FlightClass.Economy => economySeats,
                FlightClass.Business => businessSeats,
                FlightClass.FirstClass => firstClassSeats
            };

            // Act
            var seats = flight.GetAvailableSeats(flightClass);

            // Assert
            Assert.Equal(expectedSeats, seats);
        }

        [Fact]
        public void CancelBookingTest()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var booking = fixture.Create<Booking>();

            var bookings = new List<Booking> { booking };
               

            var flight = fixture.Build<Flight>()
                                .With(f => f.bookings, bookings)
                                .Create();

            // Act
            flight.CancelBooking(booking);

            // Assert
            Assert.Empty(bookings);
            
        }

        [Fact]
        public void ModifyClass_SuccessfulModification()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var flight = fixture.Create<Flight>();

            var booking = fixture.Build<Booking>()
                                .With(b => b.FlightClass, FlightClass.Economy)
                                .Create();

            flight.bookings.Add(booking);


            // Act
            flight.ModifyClass(booking, FlightClass.Business);


            // Assert
            Assert.Equal(FlightClass.Business, booking.FlightClass);
        }

    }
}
