using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.Common;

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
        public string Code { get; set; }
        public double Price { get; set; }
        public string DepartureCountry { get; set; }
        public string DestinationCountry { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
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
