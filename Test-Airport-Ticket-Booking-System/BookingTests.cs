using Airport_Ticket_Booking_System.Enums;
using Airport_Ticket_Booking_System.Model;
using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Airport_Ticket_Booking_System
{
    public class BookingTests
    {
        [Fact]
        public void CancelABookingTest()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            var flightMock = new Mock<Flight>();

            var booking = fixture.Build<Booking>()
                                .With(b => b.Flight, flightMock.Object)
                                .Create();

            flightMock.Setup(f => f.CancelBooking(booking));

            // Act
            booking.CancelBooking();

            // Assert
            flightMock.Verify(f => f.CancelBooking(booking), Times.Once);

        }

        [Theory]
        [InlineData(FlightClass.Economy)]
        [InlineData(FlightClass.Business)]
        [InlineData(FlightClass.FirstClass)]
        public void ModifyClassTest(FlightClass flightClass)
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            var flightMock = new Mock<Flight>();

            var booking = fixture.Build<Booking>()
                                .With(b => b.Flight, flightMock.Object)
                                .Create();

            flightMock.Setup(f => f.ModifyClass(booking, flightClass));

            // Act
            booking.ModifyClass(flightClass);

            // Assert
            flightMock.Verify(f => f.ModifyClass(booking, flightClass), Times.Once);

        }
    }
}
