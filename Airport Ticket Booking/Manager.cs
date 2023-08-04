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
