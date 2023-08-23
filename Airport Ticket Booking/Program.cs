using Airport_Ticket_Booking.Commons;
using Airport_Ticket_Booking.Role;
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

                if (number == 3)
                {
                    flag = false;
                }
                else
                {
                    IRole role = RoleFactory.CreateRole(number);
                    role.GetMain();
                }
            }
        }


    }
}
