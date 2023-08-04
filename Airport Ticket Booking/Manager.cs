using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.Common;

namespace Airport_Ticket_Booking
{
    public class Manager
    {
        FlightsManager FlightsManager;
        public Manager()
        {
            FlightsManager = FlightsManager.Instance();
        }

        enum ManagerOptions
        {
            ShowBookings = 1, AddCSV = 2, FieldsDetails = 3, Exit = 4
        }

        public void ManagerMain()
        {
            var Flag = true;
            while(Flag) { 
                Console.WriteLine("***************************************************");
                Console.WriteLine("************** 1. Filter Booking ******************");
                Console.WriteLine("************** 2. Add Flights *********************");
                Console.WriteLine("************** 3. Flieds Details *********************");
                Console.WriteLine("************** 4. Exit ****************************");
                Console.WriteLine("***************************************************");

                int number = (int) UserInput((int)IntOrDouble.integern, 1, 4);
                switch (number)
                {
                    case (int) ManagerOptions.ShowBookings:
                        ShowBookingsInput();
                        break;

                    case (int) ManagerOptions.AddCSV:
                        AddCSVForFlights();
                        break;

                    case (int)ManagerOptions.FieldsDetails:
                        GetFieldConstraints();
                        break;
                    case (int) ManagerOptions.Exit:
                        Flag = false;
                        break;
                }
            }
        }

        private void ShowBookingsInput()
        {
            Console.WriteLine("What You Want to Search Based On?");
            Console.WriteLine("1. Show me All the Bookings");
            Console.WriteLine("2. Departure Country");
            Console.WriteLine("3. Destination Country");
            Console.WriteLine("4. Departure Airport");
            Console.WriteLine("5. Arrival Airport");
            Console.WriteLine("6. Departure Date");
            Console.WriteLine("7. Class");
            Console.WriteLine("8. Price");
            Console.WriteLine("9. Flight Code");
            Console.WriteLine("10. Passenger Name");


            Console.WriteLine("Please Enter The Values Of Numbers That you Want to Search Based On It Separeted with Comma");
            Console.WriteLine("Like 1, 2, 5, etc");

            List<int> OptionList = TakeTheListFromUser();
            if (OptionList.Count > 0)
            {
                string DepartureCountry = null;
                string DestinationCountry = null;
                string DepartureAirport = null;
                string ArrivalAirport = null;
                DateTime? DepartureDate = null;
                FlightClass? FlightClass = null;
                double? MaxPrice = null;
                string FlightCode = null;
                string PassengerName = null;


                foreach (var option in OptionList)
                {
                    switch (option)
                    {
                        case (int)SearchBasedOn.All:
                            FlightsManager.showGivenBookings(FlightsManager.FilterBookings());
                            return;
                        case (int)SearchBasedOn.DepartureCountry:
                            Console.WriteLine("Please Enter The Departure Country");
                            DepartureCountry = Console.ReadLine();
                            break;
                        case (int)SearchBasedOn.DestinationCountry:
                            Console.WriteLine("Please Enter The Destination Country");
                            DestinationCountry = Console.ReadLine();
                            break;
                        case (int)SearchBasedOn.DepartureAirport:
                            Console.WriteLine("Please Enter The Departure Airport");
                            DepartureAirport = Console.ReadLine();
                            break;
                        case (int)SearchBasedOn.ArrivalAirport:
                            Console.WriteLine("Please Enter The Arrival Airport");
                            ArrivalAirport = Console.ReadLine();
                            break;
                        case (int)SearchBasedOn.DepartureDate:
                            Console.WriteLine("Please Enter the Day:");
                            int Day = (int)UserInput((int)IntOrDouble.integern);
                            Console.WriteLine("Please Enter the Month:");
                            int Month = (int)UserInput((int)IntOrDouble.integern);
                            Console.WriteLine("Please Enter the Year:");
                            int Year = (int)UserInput((int)IntOrDouble.integern);
                            DepartureDate = new DateTime(Year, Month, Day);
                            break;
                        case (int)SearchBasedOn.FlightClass:
                            Console.WriteLine("Please Enter the New Class:");
                            Console.WriteLine("1 : Economy");
                            Console.WriteLine("2 : Business");
                            Console.WriteLine("3 : FirstClass");
                            FlightClass = (FlightClass)UserInput((int)IntOrDouble.integern, 1, 3);
                            break;
                        case (int)SearchBasedOn.MaxPrice:
                            Console.WriteLine("Please Enter The Max Price That You Do not Want to Exceed:");
                            MaxPrice = UserInput((int)IntOrDouble.doublen);
                            break;
                        case (int)SearchBasedOn.Code:
                            Console.WriteLine("Please Enter The Flight Code:");
                            FlightCode= Console.ReadLine();
                            break;
                        case (int)SearchBasedOn.PassengerName:
                            Console.WriteLine("Please Enter The Passenger Name:");
                            PassengerName = Console.ReadLine();
                            break;

                        default:
                            break;
                    }
                }
                List<Booking> FilterBookings = FlightsManager.FilterBookings(DepartureCountry, DestinationCountry, 
                    DepartureAirport, ArrivalAirport, DepartureDate, FlightClass, MaxPrice, FlightCode, PassengerName);
                FlightsManager.showGivenBookings(FilterBookings);
            }
            else
            {
                Console.WriteLine("The Input Is Not Contains Any Options");
            }

        }

        private void AddCSVForFlights()
        {
            Console.WriteLine("Please Note that I am Expecting to Have the Data In The Following Order: ");
            Console.WriteLine("Please Note that All Fields is Required: ");
            Console.WriteLine("1. Flight Code");
            Console.WriteLine("2. Departure Country");
            Console.WriteLine("3. Destination Country");
            Console.WriteLine("4. Departure Airport");
            Console.WriteLine("5. Arrival Airport");
            Console.WriteLine("6. Departure Date");
            Console.WriteLine("7. Class");
            Console.WriteLine("8. Price");

            Console.WriteLine("Please Enter the File Path");
            string FilePath = Console.ReadLine();
            Console.WriteLine("Is There Will be Header contains Columns Name? ");
            Console.WriteLine("Press 1 if Yes");
            Console.WriteLine("Press 2 if No");
            bool isHeader = (int)UserInput((int)IntOrDouble.integern, 1, 2) == 1 ? true : false;

            try
            {
                FilePath = @$"{FilePath}";
                List<Flight> Flights = FlightsManager.ReadFromCSV(FilePath, isHeader);
                FlightsManager.showFlights(Flights);
            }
            catch  (Exception ex)
            {
                Console.WriteLine("The Path that you Entered is Not Found!");
            }
        }


        public static void GetFieldConstraints()
        {
            var flightType = typeof(Flight);
            var properties = flightType.GetProperties();
            
            foreach(var property in properties)
            {
                var constraints = property.GetCustomAttributes(typeof(FlightFieldConstraintAttribute), true)
                                         .OfType<FlightFieldConstraintAttribute>()
                                         .FirstOrDefault();

                if(constraints != null)
                {
                    Console.WriteLine($"{property.Name}");
                    Console.WriteLine($"Data Type: {constraints.DataType}");
                    Console.WriteLine($"Is Required: {constraints.IsRequired}");
                    if (!string.IsNullOrEmpty(constraints.AllowedRange)) 
                        Console.WriteLine($"Allowed Range: {constraints.AllowedRange}");
                    Console.WriteLine();

                }
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class FlightFieldConstraintAttribute: Attribute
        {
            public string DataType { get; set; }
            public bool IsRequired { get; set; }
            public string AllowedRange { get; set; }

            public FlightFieldConstraintAttribute(string dataType, bool isRequired, string allowedRange = null)
            {
                DataType = dataType;
                IsRequired = isRequired;
                AllowedRange = allowedRange;
            }
        }
    }
}
