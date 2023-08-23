using System;

namespace Airport_Ticket_Booking.Commons
{
    public class Menus
    {
        public static void ProgramMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("****** Welcome to Airport Ticket Booking *********");
            Console.WriteLine("******* 1 -> If you are Passenger please *********");
            Console.WriteLine("******* 2 -> If your are Manager please  *********");
            Console.WriteLine("****************** 3 -> Exsit  *******************");
            Console.WriteLine("**************************************************");
        }

        public static void PassengerMenu()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("************** 1. Book a Flight *******************");
            Console.WriteLine("************** 2. Show Avaliable Flights **********");
            Console.WriteLine("************** 3. Modify Booking ******************");
            Console.WriteLine("************** 4. Cancel Booking ******************");
            Console.WriteLine("************** 5. View Bookings *******************");
            Console.WriteLine("************** 6. Exit ****************************");
            Console.WriteLine("***************************************************");
        }

        public static void ManagerMenu()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("************** 1. Filter Booking ******************");
            Console.WriteLine("************** 2. Add Flights *********************");
            Console.WriteLine("************** 3. Flieds Details *********************");
            Console.WriteLine("************** 4. Exit ****************************");
            Console.WriteLine("***************************************************");
        }

        public static void ShowBookingsInputMenu()
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
        }

        public static void AddCSVForFlightsMenu()
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
        }

        public static void ShowFlightsAskInputMenu()
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
        }

        public static void ModifyAskInputMenu()
        {
            Console.WriteLine("Choose from the following what do you want to modify: ");
            Console.WriteLine("1. Modify the Passenger Name");
            Console.WriteLine("2. Modify the Flight Id");
            Console.WriteLine("3. Modify The Class");
            Console.WriteLine("4. Modify all");
        }

        public static void ClassChoiceMenu()
        {
            Console.WriteLine("Please Enter the New Class:");
            Console.WriteLine("1 : Economy");
            Console.WriteLine("2 : Business");
            Console.WriteLine("3 : FirstClass");
        }

    }
}
