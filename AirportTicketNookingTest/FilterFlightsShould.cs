using Xunit;
using Airport_Ticket_Booking;
using System;
using static Airport_Ticket_Booking.Common;

namespace AirportTicketNookingTest
{
    public class FilterFlightsShould
    {
        private readonly FlightsManager _flightManager;

        public FilterFlightsShould() {
            _flightManager = FlightsManager.Instance();
            _flightManager.ReadFromCSV(@"Flights.csv", true);
        }

        [Fact]
        public void FilterByDepartureCountry()
        {
            var filteredFlights = _flightManager.SearchFlights(DepartureCountry: "Canada");
            Assert.All(filteredFlights, flight => Assert.Equal("Canada", flight.DepartureCountry));
        }

        [Fact]
        public void FilterByDestinationCountry()
        {
            var filteredFlights = _flightManager.SearchFlights(DestinationCountry: "USA");
            Assert.All(filteredFlights, flight => Assert.Equal("USA", flight.DestinationCountry));
        }

        [Fact]
        public void FilterByDepartureAirport()
        {
            var filteredFlights = _flightManager.SearchFlights(DepartureAirport: "JFK");
            Assert.All(filteredFlights, flight => Assert.Equal("JFK", flight.DepartureAirport));
        }

        [Fact]
        public void FilterByArrivalAirport()
        {
            var filteredFlights = _flightManager.SearchFlights(ArrivalAirport: "SIN");
            Assert.All(filteredFlights, flight => Assert.Equal("SIN", flight.ArrivalAirport));
        }

        [Fact]
        public void FilterByFlightClass()
        {
            var filteredFlights = _flightManager.SearchFlights(FlightClass: FlightClass.Business);
            Assert.All(filteredFlights, flight => Assert.Equal(FlightClass.Business, flight.FClass));
        }

        [Fact]
        public void FilterByMaxPrice()
        {
            var filteredFlights = _flightManager.SearchFlights(MaxPrice: 600);
            Assert.All(filteredFlights, 
                flight => Assert.InRange(flight.Price, 0, 601));
        }

        [Fact]
        public void FilterByDepartureDate()
        {
            var date = new DateTime(2023, 9, 15);
            var filteredFlights = _flightManager.SearchFlights(DepartureDate: date);
            Assert.All(filteredFlights,
                flight => Assert.Equal(date, flight.DepartureDate));
        }
    }
}
