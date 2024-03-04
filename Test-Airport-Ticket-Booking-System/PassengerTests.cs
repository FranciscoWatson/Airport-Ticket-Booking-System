using Airport_Ticket_Booking_System.Model;
using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Airport_Ticket_Booking_System
{
    public class PassengerTests
    {
        [Fact]
        public void BookFlightTest()
        {
            // Arrenge
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var bookings = new List<Booking>();

            var passenger = fixture.Build<Passenger>()
                                .With(p => p.Bookings, bookings)
                                .Create();

            var newBooking = fixture.Create<Booking>();


            // Act
            passenger.BookFlight(newBooking);

            // Assert
            Assert.Equal(newBooking, passenger.Bookings[0]);
        }

        [Fact]
        public void CancelBookingTest()
        {
            // Arrenge
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var bookings = new List<Booking>();
            var newBooking = fixture.Create<Booking>();
            bookings.Add(newBooking);

            var passenger = fixture.Build<Passenger>()
                                .With(p => p.Bookings, bookings)
                                .Create();

            


            // Act
            passenger.CancelBooking(newBooking);

            // Assert
            Assert.Empty(passenger.Bookings);
        }
    }
}
