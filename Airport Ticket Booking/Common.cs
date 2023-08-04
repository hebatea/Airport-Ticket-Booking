using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking
{
    public static class Common
    {
        public enum FlightClass{
            Economy = 1,
            Business = 2,
            FirstClass = 3
        }

        public enum IntOrDouble
        {
            integern = 0,
            doublen = 1
        }

        public enum SearchBasedOn
        {
            All = 1,
            DepartureCountry = 2,
            DestinationCountry = 3,
            DepartureAirport = 4,
            ArrivalAirport = 5,
            DepartureDate = 6,
            FlightClass = 7,
            MaxPrice = 8,
            Code = 9,
            PassengerName = 10
        }

    public static double UserInput(int IsIntOrDouble, int? StartRange = null, int? EndRange = null)
        {
            double Output;
            int IntOutput;
            bool isVaild = false;
            do
            {
                switch (IsIntOrDouble)
                {
                    case (int)IntOrDouble.integern:

                        string userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out IntOutput))
                        {
                            isVaild = IsInRange(IntOutput, StartRange, EndRange);
                            if(isVaild)
                                return IntOutput;
                            else
                            {
                                Console.WriteLine($"Please Enter Value between {StartRange} and {EndRange}");
                            }
                                                        
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid integer value.");
                        }

                        
                        break;

                    case (int)IntOrDouble.doublen:
                        userInput = Console.ReadLine();
                        if (double.TryParse(userInput, out Output))
                        {
                            isVaild = true;
                            return Output;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid double value.");
                        }
                        break;

                    default:
                        break;
                }
            } while (!isVaild);
            return -1;
        }

        private static bool IsInRange(int input, int? StartRange = null, int? EndRange = null)
        {
            if (StartRange == null) return true;
            if (StartRange != null && EndRange != null)
            {
                if (input >= StartRange && input <= EndRange) return true;
            }
            return false;
        }

        internal static List<int> TakeTheListFromUser()
        {
            string UserInput = Console.ReadLine();
            List<int> OutputList = new List<int>();
            foreach (string input in UserInput.Split(','))
            {
                if (int.TryParse(input.Trim(), out int IntOutput))
                {
                    OutputList.Add(IntOutput);
                }
                else
                {
                    Console.WriteLine($"I can not Parse this Number{input}");
                }
            }
            return OutputList;
        }
    }
}
