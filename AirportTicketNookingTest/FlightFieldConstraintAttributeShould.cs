
using static Airport_Ticket_Booking.Manager;
using Xunit;

namespace AirportTicketNookingTest
{
    public class FlightFieldConstraintAttributeShould
    {
        [Fact]
        public void TestAttributeInitialization()
        {
            // Arrange
            string dataType = "string";
            bool isRequired = true;
            string allowedRange = "A-Z";

            // Act
            var attribute = new FlightFieldConstraintAttribute(dataType, isRequired, allowedRange);

            // Assert
            Assert.Equal(dataType, attribute.DataType);
            Assert.Equal(isRequired, attribute.IsRequired);
            Assert.Equal(allowedRange, attribute.AllowedRange);
        }
    }
}
