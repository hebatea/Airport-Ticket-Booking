using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.Common;

namespace Airport_Ticket_Booking
{
   
    enum PassengerOptions
    {
        Book = 1, Show = 2, Modify = 3, Cancel = 4, View = 5, Exit = 6
    }

    public class Passenger
    {
        FlightsManager FlightsManager;
        public Passenger()
        {
           FlightsManager = new FlightsManager();
        }
        public void PassengerMain()
        {
            var Flag = true;

            while (Flag)
            {
                Console.WriteLine("***************************************************");
                Console.WriteLine("************** 1. Book a Flight *******************");
                Console.WriteLine("************** 2. Show Avaliable Flights **********");
                Console.WriteLine("************** 3. Modify Booking ******************");
                Console.WriteLine("************** 4. Cancel Booking ******************");
                Console.WriteLine("************** 5. View Bookings *******************");
                Console.WriteLine("************** 6. Exit ****************************");
                Console.WriteLine("***************************************************");

                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out int number))
                {
                    Console.WriteLine("Please Choose Number from 1 to 6");
                    continue;
                }

                switch (number)
                {
                    case (int) PassengerOptions.Book:
                        BookAskInput();
                        break;
                    case (int) PassengerOptions.Show:
                        break;
                    case (int) PassengerOptions.Modify:
                        break;
                    case (int) PassengerOptions.Cancel:
                        break;
                    case (int) PassengerOptions.View:
                        FlightsManager.SearchFlights();
                        break;
                    case (int) PassengerOptions.Exit:
                        Flag = false;
                        break;
                    default:
                        break;
                }

            }
        }

        private void BookAskInput()
        {
            Console.WriteLine("Please Enter Your Name: ");
            string PassengerName = Console.ReadLine();

            Console.WriteLine("Please Enter the Id For your Flight: ");
            int FlightId = (int) UserInput((int) IntOrDouble.integern);
            while (!FlightsManager.isInFlights(FlightId))
            {
                Console.WriteLine("Please Enter Id from available Ids:");
                FlightId = (int)UserInput((int)IntOrDouble.integern);
            }

            Console.WriteLine("Please Enter the class:");
            Console.WriteLine("1 : Economy");
            Console.WriteLine("2 : Business");
            Console.WriteLine("3 : FirstClass");

            int ClassInput = (int)UserInput((int)IntOrDouble.integern, 1, 3);
           

            FlightsManager.BookFlight(PassengerName, FlightId, (FlightClass) ClassInput);
        }
    }
}
