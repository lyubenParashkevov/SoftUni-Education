using System;

namespace _05._Christmas_Gifts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int adoultCount = 0;
            int kidCount = 0;
            double toy = 0;
            double sweater = 0;
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Christmas")
                {
                    Console.WriteLine($"Number of adults: {adoultCount}");
                    Console.WriteLine($"Number of kids: {kidCount}");
                    Console.WriteLine($"Money for toys: {toy * 5.00}");
                    Console.WriteLine($"Money for sweaters: {sweater * 15.00}");
                    break;

                }
                int age = int.Parse(input);

                if (age <= 16)
                {
                    kidCount++;
                    toy++;
                }
                else
                {
                    adoultCount++;
                    sweater++;
                }
            }

        }
    }
}
