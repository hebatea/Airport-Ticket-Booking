using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.Common;

namespace Airport_Ticket_Booking
{
    public class DealingWithFlights
    {
        List<Flight> Flights;
        List<Booking> Bookings;


        public DealingWithFlights()
        {
            Flights = new List<Flight>();
        }

        /// <summary>
        /// Methods as passernger
        /// </summary>
        /// <param name="PathFile"></param>
        /// 
        public void BookFlight(string PassengerName, string FlightId, FlightClass flightClass)
        {

        }

        public List<Flight> SearchFlights(string departureCountry = null, string destinationCountry = null, string departureAirport = null, string arrivalAirport = null, FlightClass? flightClass = null, double? maxPrice = null)
        {
            return Flights;
        }

        public void ModifyBooking(int BookingId, FlightClass NewClass)
        {

        }

        public void CancelBooking(int BookingId)
        {

        }

        public List<Booking> ShowBooking(string PassengerName)
        {
            return Bookings;
        }



        /// <summary>
        /// Methods as Manager
        /// </summary>
        /// <param name="PathFile"></param>
        /// 

        public List<Booking> FilterBookings(string code = null, string departureCountry = null, string destinationCountry = null,
                string departureAirport = null, string arrivalAirport = null, FlightClass? flightClass = null, decimal? maxPrice = null)
        {
            return Bookings;
        }

        public void ImportFlightsFromCSV(string PathFile) 
        {
            // The validate will be add in the loop
            List<string[]> Flights = Common.ReadFromCSV(PathFile);

            try
            {
                Flight MFlight = new Flight();
                foreach (string[] StrFlight in Flights)
                {
                    MFlight.Code = StrFlight[0];
                    MFlight.Price = Convert.ToDouble(StrFlight[1]);
                    MFlight.DepartureCountry = StrFlight[2];
                    MFlight.DestinationCountry = StrFlight[3];
                    MFlight.DepartureDate = DateTime.Parse(StrFlight[4]);
                    MFlight.DepartureAirport   = StrFlight[5];
                    MFlight.ArrivalAirport     = StrFlight[6];
                    //MFlight.FClass             = StrFlight[7];

                }
            }
            catch (FileNotFoundException ex)
            {
                throw;
            }
        }




    }
}
