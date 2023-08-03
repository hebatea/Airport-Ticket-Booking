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
                        ModifyAskInput();
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

        private void ModifyAskInput()
        {
            Console.WriteLine("Please Enter The Id of the Booking that you want to modify: ");
            int id = (int)UserInput((int)IntOrDouble.integern);
            bool IsBooking = FlightsManager.IsThereBookingWithThisId(id);
            if (IsBooking)
            {
                Console.WriteLine("Choose from the following what do you want to modify: ");
                Console.WriteLine("1. Modify the Passenger Name");
                Console.WriteLine("2. Modify the Flight Id");
                Console.WriteLine("3. Modify The Class");
                Console.WriteLine("4. Modify all");

                int number = (int)UserInput((int)IntOrDouble.integern, 1, 4);
                string newPassName = null;
                int NewflightId = 1; // By the end the id will change it is just initial value
                int NewFlightClass = (int) 1;
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Please Enter the New Passenger Name:");
                        newPassName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Please Enter the New Flight Id:");
                        NewflightId = (int) UserInput((int)IntOrDouble.integern);
                        break;
                    case 3:
                        Console.WriteLine("Please Enter the New Class:");
                        Console.WriteLine("1 : Economy");
                        Console.WriteLine("2 : Business");
                        Console.WriteLine("3 : FirstClass");
                        NewFlightClass = (int)UserInput((int)IntOrDouble.integern, 1, 3);
                        break;
                    case 4:
                        Console.WriteLine("Please Enter the New Name:");
                        newPassName = Console.ReadLine();

                        Console.WriteLine("Please Enter the New Flight Id:");
                        NewflightId = (int)UserInput((int)IntOrDouble.integern);

                        Console.WriteLine("Please Enter the New Class:");
                        Console.WriteLine("1 : Economy");
                        Console.WriteLine("2 : Business");
                        Console.WriteLine("3 : FirstClass");
                        NewFlightClass = (int)UserInput((int)IntOrDouble.integern, 1, 3);
                        break;
                    default:
                        break;
                } // end switch
                FlightsManager.ModifyBooking(number, id, newPassName, NewflightId, NewFlightClass);
            }
            else
            {
                Console.WriteLine("There is no Booking with this Id!");
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
