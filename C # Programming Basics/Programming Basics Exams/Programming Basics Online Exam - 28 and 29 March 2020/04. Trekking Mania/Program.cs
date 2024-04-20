using System;

namespace _04._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numGroups = int.Parse(Console.ReadLine());
            int numPeople = 0;
            double musala = 0;
            double montblan = 0;
            double kilimangaro = 0;
            double k2 = 0;
            double everest = 0;
            int allPeople = 0;
            for (int i = 0; i < numGroups; i++)
            {
                numPeople = int.Parse(Console.ReadLine());
                if (numPeople <= 5)
                {
                    musala += numPeople;
                }
                else if (numPeople <= 12)
                {
                    montblan += numPeople;
                }
                else if (numPeople <= 25)
                {
                    kilimangaro += numPeople;
                }
                else if (numPeople <= 40)
                {
                    k2 += numPeople;
                }
                else if (numPeople >= 41)
                {
                    everest += numPeople;
                }
                allPeople += numPeople;   
            }
            Console.WriteLine($"{musala / allPeople * 100:f2}%");
            Console.WriteLine($"{montblan / allPeople * 100:f2}%");
            Console.WriteLine($"{kilimangaro / allPeople * 100:f2}%");
            Console.WriteLine($"{k2 / allPeople * 100:f2}%");
            Console.WriteLine($"{everest / allPeople * 100:f2}%");
        }
    }
}
