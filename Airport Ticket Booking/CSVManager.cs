﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking
{
    public class CSVManager
    {
        string FilePath;
        public CSVManager() {
            string currentDirectory = Environment.CurrentDirectory;
            string fileName = "Bookings.csv";
            FilePath = Path.Combine(currentDirectory, fileName);
        }

        public void SaveDataToCSV(List<Booking> BookedFlights)
        {
            bool fileExists = File.Exists(FilePath);

            using (StreamWriter sw = new StreamWriter(FilePath, true, Encoding.UTF8))
            {
                if (!fileExists)
                {
                    sw.WriteLine("Id,PassengerName,FlightId,FlightClass");
                }
                foreach(var BookedFlight in BookedFlights)
                    sw.WriteLine($"{BookedFlight.Id},{BookedFlight.PassengerName},{BookedFlight.flight.Code},{BookedFlight.FClass}");
            }

        }

      
    }
}
