﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("****** Welcome to Airport Ticket Booking *********");
            Console.WriteLine("****** If you are Passenger please press 1 *******");
            Console.WriteLine("****** If your are Manager please press 2 ********");

            string userInput = Console.ReadLine();
            int number;
            while (!int.TryParse(userInput, out number) || (number != 1 && number != 2))
            {
                Console.WriteLine("Please Choose Either 1 or 2");
                userInput = Console.ReadLine();
            }
            

            if(number == 1)
            {

            }
            else
            {

            }

            //Common.ReadFromCSV("C:\\Users\\Heba Ashour\\source\\repos\\Airport Ticket Booking\\flights.csv");
            Console.ReadKey();
        }
    }
}
