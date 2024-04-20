using System;

namespace _0._4_Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesForHour = int.Parse(Console.ReadLine());   
            int numDays = int.Parse(Console.ReadLine());
            int hoursForDay = pages / pagesForHour / numDays;
            Console.WriteLine(hoursForDay);
        }
    }
}
