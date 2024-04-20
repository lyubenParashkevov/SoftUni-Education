using System;

namespace _02._Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nDays = int.Parse(Console.ReadLine());
            int docs = 7;
            int dayCount = 1;
            int dayPatients = 0;
            int observed = 0;
            int noObserved = 0;
            for (int i = 1; i <= nDays; i++)
            {
                dayPatients = int.Parse(Console.ReadLine());
                if (dayCount == 3)
                {
                    if (noObserved > observed)
                        docs++;
                    dayCount = 0;
                }

                if (dayPatients <= docs)
                {
                    observed += dayPatients;
                }
                else
                {
                    observed += docs;
                    noObserved += dayPatients - docs;
                }
                dayCount++;

            }
            Console.WriteLine($"Treated patients: {observed}.");
            Console.WriteLine($"Untreated patients: {noObserved}.");
        }
    }
}
