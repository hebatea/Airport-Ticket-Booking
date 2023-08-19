using Airport_Ticket_Booking.Commons;
using System;
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
                Menus.ProgramMenu();

                int number = (int)UserInput((int)IntOrDouble.integerType, 1, 3);

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
        }

        
    }
}
