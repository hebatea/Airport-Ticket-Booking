using Airport_Ticket_Booking.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Airport_Ticket_Booking.Common;

namespace Airport_Ticket_Booking
{
    public partial class Manager
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
            while (Flag)
            {
                Menus.ManagerMenu();

                int number = (int)UserInput((int)IntOrDouble.integerType, 1, 4);
                switch (number)
                {
                    case (int)ManagerOptions.ShowBookings:
                        ShowBookingsInput();
                        break;

                    case (int)ManagerOptions.AddCSV:
                        AddCSVForFlights();
                        break;

                    case (int)ManagerOptions.FieldsDetails:
                        GetFieldConstraints();
                        break;
                    case (int)ManagerOptions.Exit:
                        Flag = false;
                        break;
                }
            }
        }

        

        private void ShowBookingsInput()
        {
            Menus.ShowBookingsInputMenu();

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
                            int Day = (int)UserInput((int)IntOrDouble.integerType);
                            Console.WriteLine("Please Enter the Month:");
                            int Month = (int)UserInput((int)IntOrDouble.integerType);
                            Console.WriteLine("Please Enter the Year:");
                            int Year = (int)UserInput((int)IntOrDouble.integerType);
                            DepartureDate = new DateTime(Year, Month, Day);
                            break;
                        case (int)SearchBasedOn.FlightClass:
                            Menus.ClassChoiceMenu();
                            FlightClass = (FlightClass)UserInput((int)IntOrDouble.integerType, 1, 3);
                            break;
                        case (int)SearchBasedOn.MaxPrice:
                            Console.WriteLine("Please Enter The Max Price That You Do not Want to Exceed:");
                            MaxPrice = UserInput((int)IntOrDouble.doubleType);
                            break;
                        case (int)SearchBasedOn.Code:
                            Console.WriteLine("Please Enter The Flight Code:");
                            FlightCode = Console.ReadLine();
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
            Menus.AddCSVForFlightsMenu();

            Console.WriteLine("Please Enter the File Path");
            string FilePath = Console.ReadLine();
            Console.WriteLine("Is There Will be Header contains Columns Name? ");
            Console.WriteLine("Press 1 if Yes");
            Console.WriteLine("Press 2 if No");
            bool isHeader = (int)UserInput((int)IntOrDouble.integerType, 1, 2) == 1 ? true : false;

            try
            {
                FilePath = @$"{FilePath}";
                List<Flight> Flights = FlightsManager.ReadFromCSV(FilePath, isHeader);
                FlightsManager.showFlights(Flights);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The Path that you Entered is Not Found!");
            }
        }

        

        public static void GetFieldConstraints()
        {
            var flightType = typeof(Flight);
            var properties = flightType.GetProperties();

            foreach (var property in properties)
            {
                var constraints = property.GetCustomAttributes(typeof(FlightFieldConstraintAttribute), true)
                                         .OfType<FlightFieldConstraintAttribute>()
                                         .FirstOrDefault();

                if (constraints != null)
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
    }
}
