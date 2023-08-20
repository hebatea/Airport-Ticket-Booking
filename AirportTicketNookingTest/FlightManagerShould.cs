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
            var bookedFlight = _flightManager.BookFlight(passengerName, flightId, flightClass);

            // Assert
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

        [Theory]
        [InlineData(1, "Khawla", -1, null)]
        [InlineData(2, "", 11, null)]
        [InlineData(3, "", -1, (int)FlightClass.Business)]
        [InlineData(4, "Ghada", 11, (int)FlightClass.FirstClass)]
        public void ModifyBookedFlight(int option, string newPassName, int newflightId, int? NewClass)
        {
            // Arrange

            // Book Flights
            var bookedFlight = _flightManager.BookFlight("Heba", 8, FlightClass.Economy);

            // Act
            _flightManager.ModifyBooking(option, bookedFlight.Id, newPassName, newflightId, NewClass);

            //Assert
            if(option == 1 || option == 4) bookedFlight.PassengerName.Should().Be(newPassName);
            if (option == 2 || option == 4) bookedFlight.Flight.Id.Should().Be(newflightId);
            if (option == 3 || option == 4) bookedFlight.FClass.Should().Be((FlightClass) NewClass);
        }

        [Fact]
        public void CancelBookedFlight()
        {
            // Arrange
            var bookedFlight = _flightManager.BookFlight("Heba", 8, FlightClass.Economy);

            //Act
            _flightManager.CancelBooking(bookedFlight.Id);

            //Assert
            Assert.False(_flightManager.IsThereBookingWithThisId(bookedFlight.Id));
        }

        [Fact]
        public void ShowAllBookingsBasedOnPassengerName()
        {
            // Arrange
            _flightManager.BookFlight("Heba", 8, FlightClass.Economy);
            _flightManager.BookFlight("Heba", 11, FlightClass.FirstClass);

            //Act
            var bookedFlights = _flightManager.ShowBooking("Heba");

            //Assert
            bookedFlights.Should().HaveCount(2);
        }
    }
}
