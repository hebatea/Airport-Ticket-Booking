using Airport_Ticket_Booking.Role;
using static Airport_Ticket_Booking.Common;

namespace Airport_Ticket_Booking
{
    public class RoleFactory
    {
        public static IRole CreateRole(int whichRole)
        {
            IRole role;
            switch(whichRole)
            {
                case (int) RoleEnum.Passenger:
                    role = new Passenger();
                    break;
                case (int) RoleEnum.Manager:
                    role = new Manager();
                    break;
                default:
                    role = null;
                    break;

            }
            return role;
        }
    }
}
