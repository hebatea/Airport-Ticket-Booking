using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.Common;
using static Airport_Ticket_Booking.Manager;

namespace Airport_Ticket_Booking
{
    public class Flight
    {
        private static int LastId;
        private int id;

        public Flight() {
            id = ++LastId;
        }
        public int Id
        {
            get => id;
        }

        [FlightFieldConstraint("Free Text", true)]
        public string Code { get; set; }

        [FlightFieldConstraint("Double", true, "0 -> infinity")]
        public double Price { get; set; }

        [FlightFieldConstraint("Free Text", true)]
        public string DepartureCountry { get; set; }

        [FlightFieldConstraint("Free Text", true)]
        public string DestinationCountry { get; set; }

        [FlightFieldConstraint("Date Time", true, "today -> future")]
        public DateTime DepartureDate { get; set; }

        [FlightFieldConstraint("Free Text", true)]
        public string DepartureAirport { get; set; }

        [FlightFieldConstraint("Free Text", true)]
        public string ArrivalAirport { get; set; }

        [FlightFieldConstraint("Number from 1 - 3", true, "1 -> Economy, 2 -> Business, 3 -> First Class")]
        public FlightClass FClass { get; set; }

        public override string ToString()
        {
            return $"Flight ID: {Id}" +
               $", Flight Code: {Code}" +
               $", Departure Country: {DepartureCountry}" +
               $", Destination Country: {DestinationCountry}" +
               $", Departure Airport: {DepartureAirport}" +
               $", Arrival Airport: {ArrivalAirport}" +
               $", Departure Date: {DepartureDate}" +
               $", Class: {FClass}" +
               $", Price: ${Price}\n";
        }        

    }
}
