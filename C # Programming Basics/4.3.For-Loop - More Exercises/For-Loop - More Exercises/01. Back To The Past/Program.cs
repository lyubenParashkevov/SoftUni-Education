using System;

namespace _01._Back_To_The_Past
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inheritance = double.Parse(Console.ReadLine());
            int targetYear = int.Parse(Console.ReadLine());
            double spend = 0;
            int age = 18;

            for (int i = 1800; i <= targetYear; i++)
            {
                
                if (i % 2 == 0)
                {
                    spend += 12000;
                    
                }
                else
                {
                    {
                        spend += 12000 + (50 * age);
                    }
                }
                age++;
            }
            if (inheritance >= spend)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {inheritance - spend:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {spend - inheritance:f2} dollars to survive.");
            }
        }
    }
}
