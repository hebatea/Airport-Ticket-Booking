using Airport_Ticket_Booking;
using Xunit;
using static Airport_Ticket_Booking.Common;

namespace AirportTicketNookingTest
{
    public class FliterBookingShould
    {
        private readonly FlightsManager _flightManager;

        public FliterBookingShould()
        {
            _flightManager = FlightsManager.Instance();
            _flightManager.ReadFromCSV(@"Flights.csv", true);
            _flightManager.BookFlight("Heba", 8, FlightClass.Economy);
            _flightManager.BookFlight("Khawla", 11, FlightClass.Business);
        }

        [Fact]
        public void FilterByPassengerName()
        {
            var filteredBookings = _flightManager.FilterBookings(passengerName: "Heba");
            Assert.All(filteredBookings, booking => Assert.Equal("Heba", booking.PassengerName));
        }

        [Fact]
        public void FilterByFlightClass()
        {
            var filteredBookings = _flightManager.FilterBookings(flightClass: FlightClass.Economy);
            Assert.All(filteredBookings, booking => Assert.Equal(FlightClass.Economy, booking.Flight.FClass));
        }


        [Fact]
        public void FilterByDepartureCountry()
        {
            var filteredBookings = _flightManager.FilterBookings(departureCountry: "Canada");
            Assert.All(filteredBookings, booking => Assert.Equal("Canada", booking.Flight.DepartureCountry));
        }

        [Fact]
        public void FilterByDestinationCountry()
        {
            var filteredBookings = _flightManager.FilterBookings(destinationCountry: "USA");
            Assert.All(filteredBookings, booking => Assert.Equal("USA", booking.Flight.DestinationCountry));
        }

        [Fact]
        public void FilterByDepartureAirport()
        {
            var filteredBookings = _flightManager.FilterBookings(departureAirport: "JFK");
            Assert.All(filteredBookings, booking => Assert.Equal("JFK", booking.Flight.DepartureAirport));
        }

        [Fact]
        public void FilterByArrivalAirport()
        {
            var filteredBookings = _flightManager.FilterBookings(arrivalAirport: "SIN");
            Assert.All(filteredBookings, booking => Assert.Equal("SIN", booking.Flight.ArrivalAirport));
        }

        [Fact]
        public void FilterByMaxPrice()
        {
            var filteredBookings = _flightManager.FilterBookings(maxPrice: 600);
            Assert.All(filteredBookings,
                booking => Assert.InRange(booking.Flight.Price, 0, 601));
        }

    }
}
