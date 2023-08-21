using Airport_Ticket_Booking;
using System;
using System.Collections.Generic;
using Xunit;

namespace AirportTicketNookingTest
{
    public class CSVShould
    {
        private readonly FlightsManager _flightManager;

        public CSVShould()
        {
            _flightManager = FlightsManager.Instance();

        }

        [Fact]
        public void ReadFromCSV()
        {

            List<Flight> flights = _flightManager.ReadFromCSV(@"Flights.csv", true);

            Assert.NotNull(flights);
            Assert.All(flights, flight => Assert.True(flight.DepartureDate >= DateTime.Now));
            Assert.All(flights, flight => Assert.False(flight.Price < 0));
            Assert.All(flights, flight => Assert.False(string.IsNullOrEmpty(flight.Code)));
            Assert.All(flights, flight => Assert.False(string.IsNullOrEmpty(flight.DepartureCountry)));
            Assert.All(flights, flight => Assert.False(string.IsNullOrEmpty(flight.DestinationCountry)));
            Assert.All(flights, flight => Assert.False(string.IsNullOrEmpty(flight.DepartureAirport)));
            Assert.All(flights, flight => Assert.False(string.IsNullOrEmpty(flight.ArrivalAirport)));

        }
    }
}
