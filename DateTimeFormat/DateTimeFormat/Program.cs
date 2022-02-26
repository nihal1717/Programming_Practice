using System;

namespace DateTimeFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateVar;
            DateTime dates;
            Console.WriteLine("Enter the date in mm/dd/YYYY format");
            dateVar = Console.ReadLine();
            bool convFlag = DateTime.TryParse(dateVar, out dates);
            Console.WriteLine(dates);
            Console.WriteLine(dates.ToString("yyyy'-'MM'-'dd"));
            convFlag = DateTime.TryParseExact(dateVar, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dates);
            Console.WriteLine(dates.ToString("yyyy'-'MM'-'dd"));
        }
    }
}
