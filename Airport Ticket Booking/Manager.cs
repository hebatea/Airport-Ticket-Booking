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
            FlightsManager = new FlightsManager();
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
