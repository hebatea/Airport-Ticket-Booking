using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking
{
    public static class Common
    {
        public enum FlightClass{
            Economy,
            Business,
            FirstClass
        }

        public static List<string[]> ReadFromCSV(string FilePath) 
        {
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("The file was not found.", FilePath);
            }

            List<string[]> csvData = new List<string[]>();

            
            using (StreamReader Reader = new StreamReader(FilePath))
            {
                while (!Reader.EndOfStream)
                {
                    string Line = Reader.ReadLine();
                    string[] Fields = Line.Split(',');

                    csvData.Add(Fields);

                }
            }

            return csvData;

        }

    }
}
