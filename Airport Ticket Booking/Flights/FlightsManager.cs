using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Airport_Ticket_Booking.Common;

namespace Airport_Ticket_Booking
{
    public class FlightsManager
    {
        private List<Flight> Flights;
        private List<Booking> Bookings;
        private CSVManager CSVManager;
        private static FlightsManager FlightManager;

        public static FlightsManager Instance()
        {
            if (FlightManager == null)
            {
                FlightManager = new FlightsManager();
            }
            return FlightManager;
        }

        protected FlightsManager()
        {
            Flights = new List<Flight>();
            Bookings = new List<Booking>();
        }

        public Booking BookFlight(string PassengerName, int FlightId, FlightClass FlightClass)
        {
            if (!isInFlights(FlightId)) return null;
            Booking Booking = new Booking()
            {
                PassengerName = PassengerName,
                Flight = Flights.Single(f => f.Id == FlightId),
                FClass = FlightClass

            };
            Bookings.Add(Booking);
            return Booking;
        }


        public bool isInFlights(int FlightId)
        {
            try
            {
                Flights.Single(f => f.Id == FlightId);
            }
            catch (Exception)
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
                    if (isInFlights(newflightId))
                        bookedFlight.Flight = Flights.Single(f => f.Id == newflightId);
                    break;
                case 3:
                    bookedFlight.FClass = (FlightClass)NewClass;
                    break;
                case 4:
                    bookedFlight.PassengerName = newPassName;
                    if (isInFlights(newflightId))
                        bookedFlight.Flight = Flights.Single(f => f.Id == newflightId);
                    bookedFlight.FClass = (FlightClass)NewClass;
                    break;
                default:
                    break;
            }

            Console.WriteLine("Here is the new information for the updated product:");
            Console.WriteLine($"Id: {bookedFlight.Id}, Passenger Name: {bookedFlight.PassengerName}, " +
                $"Flight Id: {bookedFlight.Flight.Id}, Class (1 - Economy, 2 - Bussiness, 3 - First Class): {bookedFlight.FClass}");

        }


        public List<Flight> SearchFlights(string DepartureCountry = null, string DestinationCountry = null,
            string DepartureAirport = null, string ArrivalAirport = null, DateTime? DepartureDate = null,
            FlightClass? FlightClass = null, double? MaxPrice = null)
        {
            var query = Flights.AsQueryable();

            if (!string.IsNullOrEmpty(DepartureCountry))
                query = query.Where(f => f.DepartureCountry.Equals(DepartureCountry, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(DestinationCountry))
                query = query.Where(f => f.DestinationCountry.Equals(DestinationCountry, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(DepartureAirport))
                query = query.Where(f => f.DepartureAirport.Equals(DepartureAirport, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(ArrivalAirport))
                query = query.Where(f => f.ArrivalAirport.Equals(ArrivalAirport, StringComparison.OrdinalIgnoreCase));

            if (DepartureDate != null)
                query = query.Where(f => f.DepartureDate.Equals(DepartureDate));

            if (FlightClass != null)
                query = query.Where(f => f.FClass.Equals(FlightClass));

            if (MaxPrice != null)
                query = query.Where(f => f.Price <= MaxPrice);

            return query.ToList();
        }

        public void showFlights(List<Flight> QueryFlights)
        {
            if (QueryFlights.Count == 0)
            {
                Console.WriteLine("There is Nothing Matched Your Criterias!");
            }

            foreach (var flight in QueryFlights)
            {
                Console.WriteLine(flight);
            }
        }

        public void showGivenBookings(List<Booking> QueryBooking)
        {
            if (QueryBooking.Count == 0)
            {
                Console.WriteLine("There is Nothing Matched Your Criterias!");
            }

            foreach (var BookedFlight in QueryBooking)
            {
                Console.WriteLine(BookedFlight);
            }
        }


        public bool IsThereBookingWithThisId(int BookingId)
        {
            try
            {
                Booking b = Bookings.Single(f => f.Id == BookingId);
                Console.WriteLine("Here is the old information for the Booking:");
                Console.WriteLine($"Id: {b.Id}, Passenger Name: {b.PassengerName}, " +
                    $"Flight Id: {b.Flight.Id}, Class (1 - Economy, 2 - Bussiness, 3 - First Class): {b.FClass}");

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void CancelBooking(int BookingId)
        {
            Bookings.RemoveAll(b => b.Id == BookingId);
        }

        public List<Booking> ShowBooking(string PassengerName)
        {
            List<Booking> BookingsBasedOnName = Bookings.Where(b => b.PassengerName == PassengerName).ToList();

            return BookingsBasedOnName;
        }


        public List<Booking> FilterBookings(string departureCountry = null, string destinationCountry = null,
                string departureAirport = null, string arrivalAirport = null, DateTime? DepartureDate = null, FlightClass? flightClass = null, double? maxPrice = null,
                string code = null, string passengerName = null)
        {
            var filteredBookings = Bookings;

            if (code != null)
            {
                filteredBookings = filteredBookings.Where(booking => booking.Flight.Code == code).ToList();
            }

            if (passengerName != null)
            {
                filteredBookings = filteredBookings.Where(booking => booking.PassengerName == passengerName).ToList();
            }

            if (departureCountry != null)
            {
                filteredBookings = filteredBookings.Where(booking => booking.Flight.DepartureCountry == departureCountry).ToList();
            }

            if (destinationCountry != null)
            {
                filteredBookings = filteredBookings.Where(booking => booking.Flight.DestinationCountry == destinationCountry).ToList();
            }

            if (departureAirport != null)
            {
                filteredBookings = filteredBookings.Where(booking => booking.Flight.DepartureAirport == departureAirport).ToList();
            }

            if (arrivalAirport != null)
            {
                filteredBookings = filteredBookings.Where(booking => booking.Flight.ArrivalAirport == arrivalAirport).ToList();
            }

            if (flightClass.HasValue)
            {
                filteredBookings = filteredBookings.Where(booking => booking.Flight.FClass == flightClass).ToList();
            }

            if (maxPrice.HasValue)
            {
                filteredBookings = filteredBookings.Where(booking => booking.Flight.Price <= maxPrice).ToList();
            }

            return filteredBookings;
        }

        public List<Flight> ReadFromCSV(string FilePath, bool isHeader)
        {
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("The file was not found.", FilePath);
            }

            var Include = isHeader ? false : true;
            List<string> ErrorsExceptionsList = new List<string>();
            string ErrorsMesssage;
            bool ShouldAdded;
            using (StreamReader Reader = new StreamReader(FilePath))
            {
                int rowCount = -1;
                while (!Reader.EndOfStream)
                {
                    ErrorsMesssage = "";
                    rowCount++;
                    ShouldAdded = true;
                    Flight NewFlight = new Flight();

                    string Line = Reader.ReadLine();
                    string[] Fields = Line.Split(',');
                    if (!Include) { Include = true; continue; }

                    string FlightCode = Fields[0];
                    string DepartureCountry = Fields[1];
                    string DestinationCountry = Fields[2];
                    string DepartureAirport = Fields[3];
                    string ArrivalAirport = Fields[4];

                    try
                    {
                        NewFlight.Code = FlightCode;
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorsMesssage += ex.Message;
                        ShouldAdded = false;
                    }

                    try
                    {
                        NewFlight.DepartureCountry = DepartureCountry;
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorsMesssage += ex.Message;
                        ShouldAdded = false;
                    }

                    try
                    {
                        NewFlight.DestinationCountry = DestinationCountry;
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorsMesssage += ex.Message;
                        ShouldAdded = false;
                    }

                    try
                    {
                        NewFlight.DepartureAirport = DepartureAirport;
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorsMesssage += ex.Message;
                        ShouldAdded = false;
                    }

                    try
                    {
                        NewFlight.ArrivalAirport = ArrivalAirport;
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorsMesssage += ex.Message;
                        ShouldAdded = false;
                    }



                    DateTime DepartureDate;
                    try
                    {
                        DepartureDate = DateTime.Parse(Fields[5]);
                        NewFlight.DepartureDate = DepartureDate;
                    }
                    catch (FormatException ex)
                    {
                        ErrorsMesssage += "Error: Unable to parse Departure Date DateTime using DateTime.Parse.";
                        ErrorsMesssage += "Exception message: " + ex.Message + "\n";
                        ShouldAdded = false;
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorsMesssage += ex.Message;
                        ShouldAdded = false;
                    }

                    int FClass;

                    if (int.TryParse(Fields[6], out FClass))
                    {
                        try
                        {
                            NewFlight.FClass = (FlightClass)FClass;
                        }
                        catch (ArgumentException ex)
                        {
                            ErrorsMesssage += ex.Message;
                            ShouldAdded = false;
                        }
                    }
                    else
                    {
                        ErrorsMesssage += "Error: Unable to parse Flight Class integer using int.TryParse.\n";
                        ShouldAdded = false;
                    }

                    double Price;
                    if (double.TryParse(Fields[7], out Price))
                    {
                        try
                        {
                            NewFlight.Price = Price;
                        }
                        catch (ArgumentException ex)
                        {
                            ErrorsMesssage += ex.Message;
                            ShouldAdded = false;
                        }
                    }
                    else
                    {
                        ErrorsMesssage += "Error: Unable to parse Price to double using double.TryParse.\n";
                        ShouldAdded = false;
                    }


                    if (ShouldAdded)
                        Flights.Add(NewFlight);
                    else
                    {
                        ErrorsMesssage = $"Row : {rowCount} Can not added becuase of:\n" + ErrorsMesssage;
                        ErrorsExceptionsList.Add(ErrorsMesssage);
                    }

                }
            }

            foreach (var Error in ErrorsExceptionsList)
            {
                Console.WriteLine(Error);
            }

            return Flights;

        }


    }
}
