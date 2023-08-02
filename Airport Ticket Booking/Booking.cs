﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Ticket_Booking.Common;

namespace Airport_Ticket_Booking
{
    public class Booking
    {
        private static int LastId;
        private int id;

        public Booking()
        {
            id = ++LastId;
        }
        public int Id
        {
            get => id;
        }
        public Flight flight { get; set; }
        public string PassengerName { get; set; }
        public FlightClass FClass { get; set; } // I am not sure if I should add it or not
    }
}
