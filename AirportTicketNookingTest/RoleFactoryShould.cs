using Airport_Ticket_Booking;
using FluentAssertions;
using Xunit;
using static Airport_Ticket_Booking.Common;

namespace AirportTicketNookingTest
{
    public class RoleFactoryShould
    {
        [Fact]
        public void returnManagerObjectWhenManagerNeeded()
        {
            var manager = RoleFactory.CreateRole((int )RoleEnum.Manager);
            Assert.NotNull(manager);
            manager.Should().BeOfType<Manager>();
        }

        [Fact]
        public void returnPassengerObjectWhenPassengerNeeded()
        {
            var passenger = RoleFactory.CreateRole((int)RoleEnum.Passenger);
            Assert.NotNull(passenger);
            passenger.Should().BeOfType<Passenger>();
        }
    }
}
