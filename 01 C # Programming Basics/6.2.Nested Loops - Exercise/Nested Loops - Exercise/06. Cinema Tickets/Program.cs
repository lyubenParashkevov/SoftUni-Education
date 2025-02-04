using System;

namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int standartCount = 0;
            int studentCount = 0;   
            int kidCount = 0;
            int tottalTickets = 0;
            
            while (true)
            {
                string movie = Console.ReadLine();

                if (movie == "Finish")
                {
                    Console.WriteLine($"Total tickets: {tottalTickets}");
                    Console.WriteLine($"{(studentCount * 100.00 / tottalTickets):f2}% student tickets.");
                    Console.WriteLine($"{(standartCount * 100.00 / tottalTickets):f2}% standard tickets.");
                    Console.WriteLine($"{(kidCount * 100.00 / tottalTickets):f2}% kids tickets.");
                    return;
                }
                int seats = int.Parse(Console.ReadLine());

                int movieTickets = 0;
                while (true)
                {
                    

                    if (movieTickets == seats)
                    {
                        Console.WriteLine($"{movie} - {(movieTickets * 100.00 / seats):f2}% full.");
                        break;
                    }
                    string ticketTipe = Console.ReadLine();
                                     
                    if (ticketTipe == "standard")
                    {
                        standartCount++;
                        tottalTickets++;
                    }
                    else if (ticketTipe == "student")
                    {
                        studentCount++;
                        tottalTickets++;
                    }
                    else if (ticketTipe == "kid")
                    {
                        kidCount++;
                        tottalTickets++;
                    }
                    if (ticketTipe == "End")
                    {
                        Console.WriteLine($"{movie} - {(movieTickets * 100.00 / seats):f2}% full.");
                        break; 
                    }
                    if (ticketTipe == "Finish")
                    {
                        Console.WriteLine($"{movie} - {(movieTickets * 100.00 / seats):f2}% full.");
                        Console.WriteLine($"Total tickets: {tottalTickets}");
                        Console.WriteLine($"{(studentCount * 100.00 / tottalTickets):f2}% student tickets.");
                        Console.WriteLine($"{(standartCount * 100.00 / tottalTickets):f2}% standard tickets.");
                        Console.WriteLine($"{(kidCount * 100.00 / tottalTickets):f2}% kids tickets.");
                        return;
                    }
                    movieTickets++;
                    
                }
            }
        }
    }
}
                        
                        

                        

                
                

                
