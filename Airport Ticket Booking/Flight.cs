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
        private string code;
        private double price;
        private string departureCountry;
        private string destinationCountry;
        private DateTime departureDate;
        private string departureAirport;
        private string arrivalAirport;
        private FlightClass fClass;

        public Flight() {
            id = ++LastId;
        }
        public int Id
        {
            get => id;
        }

        [FlightFieldConstraint("Free Text", true)]
        public string Code
        {
            get => code; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Code cannot be null or empty.");
                }

                code = value.Trim();
            }
        }

        [FlightFieldConstraint("Double", true, "0 -> infinity")]
        public double Price { get => price;
            set{
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be a negative number.\n");
                }
                price = value; 
            }
        }

        [FlightFieldConstraint("Free Text", true)]
        public string DepartureCountry { get => departureCountry;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Departure Country cannot be null or empty.\n");
                }
                departureCountry = value.Trim(); 
            }
        }

        [FlightFieldConstraint("Free Text", true)]
        public string DestinationCountry { get => destinationCountry;
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Destination Country cannot be null or empty.\n");
                }
                destinationCountry = value.Trim();
            }
        }

        [FlightFieldConstraint("Date Time", true, "today -> future")]
        public DateTime DepartureDate { get => departureDate; 
            set {
                if (value <= DateTime.Now)
                {
                    throw new ArgumentException("Departure Date must be a date in the future.\n");
                }
                departureDate = value;
            }
        }

        [FlightFieldConstraint("Free Text", true)]
        public string DepartureAirport { get => departureAirport;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Departure Airport cannot be null or empty.\n");
                }
                departureAirport = value.Trim();
            }
        }

        [FlightFieldConstraint("Free Text", true)]
        public string ArrivalAirport { get => arrivalAirport;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Arrival Airport cannot be null or empty.\n");
                }
                arrivalAirport = value.Trim();
            }
        }

        [FlightFieldConstraint("Number from 1 - 3", true, "1 -> Economy, 2 -> Business, 3 -> First Class")]
        public FlightClass FClass { get => fClass; 
            set {
                if ((int) value < 1 || (int) value > 3)
                {
                    throw new ArgumentException("Flight Class Should be From 1 to 3.\n");
                }
                fClass = value; 
            } 
        }

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
