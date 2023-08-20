using Airport_Ticket_Booking;
using AutoFixture;
using System.IO;
using System;
using Xunit;
using static Airport_Ticket_Booking.Common;
using FluentAssertions;

namespace AirportTicketNookingTest
{
    public class FlightManagerShould
    {
        private readonly Fixture _fixture;
        private readonly FlightsManager _flightManager;

        public FlightManagerShould() {
            _fixture = new Fixture();
            _flightManager = FlightsManager.Instance();
            
            _flightManager.ReadFromCSV(@"Flights.csv", true);
        }   
        
        private string GiveFullPath(string fileName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(basePath, fileName);
            return fullPath;
        }

        [Fact]
        public void BookFlightWithExistingFlightId()
        {
            // Arrange   
            var passengerName = _fixture.Create<string>();
            var flightId = 8;
            var flightClass = _fixture.Create<Common.FlightClass>();

            // Act
            _flightManager.BookFlight(passengerName, flightId, flightClass);

            // Assert
            var bookedFlight = _flightManager.FilterBookings(passengerName: passengerName)[0];
            bookedFlight.PassengerName.Should().Be(passengerName);
            bookedFlight.Flight.Id.Should().Be(flightId);
            bookedFlight.FClass.Should().Be(flightClass);
        }

        [Fact]
        public void BookFlightWithNotExistingFlightId()
        {
            // Arrange   
            var passengerName = _fixture.Create<string>();
            var flightId = 3;
            var flightClass = _fixture.Create<Common.FlightClass>();

            // Act
            _flightManager.BookFlight(passengerName, flightId, flightClass);

            // Assert
            var bookedFlight = _flightManager.FilterBookings(passengerName: passengerName);
            bookedFlight.Should().HaveCount(0);
        }



    }
}
