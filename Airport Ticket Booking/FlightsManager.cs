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
    public class FlightsManager
    {
        List<Flight> Flights;
        List<Booking> Bookings;
        CSVManager CSVManager;  // For Further Improvment

        public FlightsManager()
        {
            Flights = new List<Flight>();
            Bookings = new List<Booking>();
            // just for test purpose
            ReadFromCSV("C:\\Users\\Heba Ashour\\source\\repos\\Airport Ticket Booking\\Airport Ticket Booking\\Flights.csv");
        }

        /// <summary>
        /// Methods as passernger
        /// </summary>
        /// <param name="PathFile"></param>
        /// 
        public void BookFlight(string PassengerName, int FlightId, FlightClass FlightClass)
        {
            Booking Booking = new Booking()
            {
                PassengerName = PassengerName,
                flight = Flights.Single(f => f.Id == FlightId),
                FClass = FlightClass

            };
            Bookings.Add(Booking);
        }


        public bool isInFlights(int FlightId)
        {
            try
            {
                Flights.Single(f => f.Id == FlightId);
            }catch(Exception ex)
            {
                Console.WriteLine("The Flight Number does not exsit");
                return false;
            }
            return true;
        }

        public void ModifyBooking(int option, int BookingId, string newPassName, int newflightId, int? NewClass)
        {
            Booking bookedFlight = Bookings.Single(b => b.Id == BookingId);
            switch (option)
            {
                case 1:
                    bookedFlight.PassengerName = newPassName;
                    break;

                case 2:
                    if(isInFlights(newflightId))
                        bookedFlight.flight = Flights.Single(f => f.Id == newflightId);
                    break;
                case 3:
                    bookedFlight.FClass = (FlightClass) NewClass;
                    break;
                case 4:
                    bookedFlight.PassengerName = newPassName;
                    if (isInFlights(newflightId))
                        bookedFlight.flight = Flights.Single(f => f.Id == newflightId);
                    bookedFlight.FClass = (FlightClass) NewClass;
                    break;
                default:
                    break;
            }

            Console.WriteLine("Here is the new information for the updated product:");
            Console.WriteLine($"Id: {bookedFlight.Id}, Passenger Name: {bookedFlight.PassengerName}, " +
                $"Flight Id: {bookedFlight.flight.Id}, Class (1 - Economy, 2 - Bussiness, 3 - First Class): {bookedFlight.FClass}");

        }


        public List<Flight> SearchFlights(string DepartureCountry = null, string DestinationCountry = null,
            string DepartureAirport = null, string ArrivalAirport = null, DateTime? DepartureDate = null,
            FlightClass? FlightClass = null, double? MaxPrice = null)
        {
            var query = Flights.AsQueryable();

            if (!string.IsNullOrEmpty(DepartureCountry))
                query.Where(f => f.DepartureCountry.Equals(DepartureCountry, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(DestinationCountry))
                query.Where(f => f.DestinationCountry.Equals(DestinationCountry, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(DepartureAirport))
                query.Where(f => f.DepartureAirport.Equals(DepartureAirport, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(ArrivalAirport))
                query.Where(f => f.ArrivalAirport.Equals(ArrivalAirport, StringComparison.OrdinalIgnoreCase));

            if (DepartureDate != null)
                query.Where(f => f.DepartureDate.Equals(DepartureDate));

            if (FlightClass != null)
                query.Where(f => f.FClass.Equals(FlightClass));

            if (MaxPrice != null)
                query.Where(f => f.Price <= MaxPrice);
            
            showFlights(query.ToList());
            return query.ToList();
        }

        public void showFlights(List<Flight> QueryFlights)
        {
            foreach(var flight in QueryFlights)
            {
                Console.WriteLine(flight);
            }
        }

      
        public bool IsThereBookingWithThisId(int BookingId)
        {
            try
            {
                Booking b = Bookings.Single(f => f.Id == BookingId);
                Console.WriteLine("Here is the old information for the updated product:");
                Console.WriteLine($"Id: {b.Id}, Passenger Name: {b.PassengerName}, " +
                    $"Flight Id: {b.flight.Id}, Class (1 - Economy, 2 - Bussiness, 3 - First Class): {b.FClass}");

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
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

        public List<Flight> ReadFromCSV(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("The file was not found.", FilePath);
            }

            List<string[]> csvData = new List<string[]>();
            var Include = false;

            using (StreamReader Reader = new StreamReader(FilePath))
            {
                while (!Reader.EndOfStream)
                {


                    string Line = Reader.ReadLine();
                    string[] Fields = Line.Split(',');
                    if (!Include) { Include = true; continue; }

                    Flight MFlight = new Flight();

                    MFlight.Code = Fields[0];
                    //MFlight.Price = Convert.ToDouble(Fields[1]);
                    MFlight.DepartureCountry = Fields[2];
                    MFlight.DestinationCountry = Fields[3];
                    //MFlight.DepartureDate = Fields.Parse(StrFlight[4]);
                    MFlight.DepartureAirport = Fields[5];
                    MFlight.ArrivalAirport = Fields[6];
                    //MFlight.FClass             = StrFlight[7];

                    Flights.Add(MFlight);

                }
            }
            return Flights;

        }

        internal void ModifyBooking(int id, string newPassName, int? newflightId, FlightClass? newFlightClass)
        {
            throw new NotImplementedException();
        }
    }
}
