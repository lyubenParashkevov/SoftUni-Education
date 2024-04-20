using System;

namespace _07._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Група до 5 човека – изкачват Мусала
            //•	Група от 6 до 12 човека – изкачват Монблан
            //•	Група от 13 до 25 човека – изкачват Килиманджаро
            //•	Група от 26 до 40 човека –  изкачват К2
             //•	Група от 41 или повече човека – изкачват Еверест

            int nGroups = int.Parse(Console.ReadLine());
            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            int group4 = 0;
            int group5 = 0;
            int allPeople = 0;
            int numPeople = 0;
            for (int i = 0; i < nGroups; i++)
            {
                numPeople = int.Parse(Console.ReadLine());

                if(numPeople <= 5)
                {
                    group1 += numPeople;
                }
                else if (numPeople <= 12)
                {
                    group2 += numPeople;
                }
                else if (numPeople <= 25)
                {
                    group3 += numPeople;
                }
                 else if (numPeople <= 40)
                {
                    group4 += numPeople;
                }      
                else if (numPeople >= 41)
                {
                    group5 += numPeople;
                }
                allPeople =group1 + group2 + group3 + group4 + group5;
            }
            Console.WriteLine($"{(double)group1 / allPeople * 100:f2}%");
            Console.WriteLine($"{(double)group2 / allPeople * 100:f2}%");
            Console.WriteLine($"{(double)group3 / allPeople * 100:f2}%");
            Console.WriteLine($"{(double)group4 / allPeople * 100:f2}%");
            Console.WriteLine($"{(double)group5 / allPeople * 100:f2}%");

        }
    }
}
