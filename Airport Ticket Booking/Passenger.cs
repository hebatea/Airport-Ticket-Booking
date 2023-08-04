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
            FlightsManager = FlightsManager.Instance();
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
                        ShowFlightsAskInput();
                        break;
                    case (int) PassengerOptions.Modify:
                        ModifyAskInput();
                        break;
                    case (int) PassengerOptions.Cancel:
                        CancelAskInput();
                        break;
                    case (int) PassengerOptions.View:
                        ViewAskInput();
                        break;
                    case (int) PassengerOptions.Exit:
                        Flag = false;
                        break;
                    default:
                        break;
                }

            }
        }

        private void ShowFlightsAskInput()
        {
            Console.WriteLine("What You Want to Search Based On?");
            Console.WriteLine("1. Show me All the Flights");
            Console.WriteLine("2. Departure Country");
            Console.WriteLine("3. Destination Country");
            Console.WriteLine("4. Departure Airport");
            Console.WriteLine("5. Arrival Airport");
            Console.WriteLine("6. Departure Date");
            Console.WriteLine("7. Class");
            Console.WriteLine("8. Price\n");


            Console.WriteLine("Please Enter The Values Of Numbers That you Want to Search Based On It Separeted with Comma");
            Console.WriteLine("Like 1, 2, 5, etc");

            List<int> OptionList = TakeTheListFromUser();
            if(OptionList.Count > 0)
            {
                string DepartureCountry = null;
                string DestinationCountry = null;
                string DepartureAirport = null;
                string ArrivalAirport = null;
                DateTime? DepartureDate = null;
                FlightClass? FlightClass = null;
                double? MaxPrice = null;


                foreach (var option in OptionList)
                {
                    switch (option)
                    {
                        case (int) SearchBasedOn.All:
                            FlightsManager.showFlights(FlightsManager.SearchFlights());
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
                            FlightClass = (FlightClass) UserInput((int)IntOrDouble.integern, 1, 3);
                            break;
                        case (int)SearchBasedOn.MaxPrice:
                            Console.WriteLine("Please Enter The Max Price That You Do not Want to Exceed:");
                            MaxPrice = UserInput((int)IntOrDouble.doublen);
                            break;
                        default:
                            break;
                    }
                }
                List<Flight> FilterFlights = FlightsManager.SearchFlights(DepartureCountry, DestinationCountry, DepartureAirport, ArrivalAirport, DepartureDate, FlightClass, MaxPrice);
                FlightsManager.showFlights(FilterFlights);
            }
            else
            {
                Console.WriteLine("The Input Is Not Contains Any Options");
            }

        }

        private void CancelAskInput()
        {
            Console.WriteLine("Please Enter The Id of the Booking you Want to Cancel: ");
            int id = (int)UserInput((int)IntOrDouble.integern);
            if (!FlightsManager.IsThereBookingWithThisId(id))
            {
                Console.WriteLine("There is no Booking with this Id!");
            }
            else
            { 
                FlightsManager.CancelBooking(id);
                Console.WriteLine("Cancelled Successfully");
            }
        }

        private void ViewAskInput()
        {
            Console.WriteLine("Please Enter The Name that You Booked Using It");
            string Name = Console.ReadLine();
            List<Booking> BookingsName = FlightsManager.ShowBooking(Name);
            if(BookingsName == null)
            {
                Console.WriteLine("There is no booking assigned to this name!");
            }
            foreach(Booking bookedFlight in BookingsName)
            {
                Console.WriteLine($"Id: {bookedFlight.Id}, Passenger Name: {bookedFlight.PassengerName}, " +
               $"Flight Calss: {bookedFlight.FClass}, Flight Information: ");
                Console.WriteLine($"{bookedFlight.flight}");
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
