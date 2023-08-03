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
        

    }
}
