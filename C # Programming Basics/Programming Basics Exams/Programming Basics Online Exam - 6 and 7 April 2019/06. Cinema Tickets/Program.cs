using System;

namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double studentCount = 0;
            double standartCount = 0;
            double kidCount = 0;
            double allTicketCount = 0;
            double movieTicketCount = 0;
            string ticketTipe = "";
            while (true)
            {
                string movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    Console.WriteLine($"Total tickets: {allTicketCount}");
                    Console.WriteLine($"{studentCount / allTicketCount * 100:f2}% student tickets.");
                    Console.WriteLine($"{standartCount / allTicketCount * 100:f2}% standard tickets.");
                    Console.WriteLine($"{kidCount / allTicketCount * 100:f2}% kids tickets.");
                    return;
                }
                int seats = int.Parse(Console.ReadLine());
                
                while (true)
                {
                    if (movieTicketCount == seats)
                    {
                        Console.WriteLine($"{movie} - {movieTicketCount / seats * 100:f2}% full.");
                        break;
                    }
                    ticketTipe = Console.ReadLine();
                    if (ticketTipe == "End")
                    {
                        Console.WriteLine($"{movie} - {movieTicketCount / seats * 100:f2}% full.");
                        movieTicketCount = 0;
                       break;
                    }
                    if (ticketTipe == "student")
                    {
                        studentCount++;
                        allTicketCount++;
                        movieTicketCount++;
                    }
                    else if (ticketTipe == "standard")
                    {
                        standartCount++;
                        allTicketCount++;
                        movieTicketCount++;
                    }
                    else if (ticketTipe == "kid")
                    {
                        kidCount++;
                        allTicketCount++;
                        movieTicketCount++;
                    }
                }
            }
        }
    }
}
