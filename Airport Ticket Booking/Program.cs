using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.Common;

namespace Airport_Ticket_Booking
{
    public class Program
    {
        static void Main(string[] args)
        {
            var flag = true;
            while (flag)
            {

                Console.WriteLine("**************************************************");
                Console.WriteLine("****** Welcome to Airport Ticket Booking *********");
                Console.WriteLine("******* 1 -> If you are Passenger please *********");
                Console.WriteLine("******* 2 -> If your are Manager please  *********");
                Console.WriteLine("****************** 3 -> Exsit  *******************");
                Console.WriteLine("**************************************************");


                int number = (int) UserInput((int)IntOrDouble.integern, 1, 3);

                if (number == 1)
                {
                    Passenger passenger = new Passenger();
                    passenger.PassengerMain();

                }
                else if (number == 2)
                {
                    Manager manager = new Manager();
                    manager.ManagerMain();
                }
                else
                {
                    flag = false;
                }
            }
            //Common.ReadFromCSV("C:\\Users\\Heba Ashour\\source\\repos\\Airport Ticket Booking\\flights.csv");
        }
    }
}
