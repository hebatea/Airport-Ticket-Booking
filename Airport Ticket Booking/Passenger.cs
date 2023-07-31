using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking
{
    enum PassengerOptions
    {
        Book = 1, Show = 2, Modify = 3, Cancel = 4, View = 5, Exit = 6
    }
    public class Passenger
    {
        public void PassengerMain()
        {
            var flag = true;
            while (flag)
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
                        break;
                    case (int) PassengerOptions.Show:
                        break;
                    case (int) PassengerOptions.Modify:
                        break;
                    case (int) PassengerOptions.Cancel:
                        break;
                    case (int) PassengerOptions.View:
                        break;
                    case (int) PassengerOptions.Exit:
                        flag = false;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
