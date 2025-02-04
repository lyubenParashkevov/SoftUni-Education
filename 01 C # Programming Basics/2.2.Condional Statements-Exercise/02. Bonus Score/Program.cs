using System;

namespace _02._Bonus___Scores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonnus = 0.0;

            if (number <= 100)
            {
                bonnus = 5;
            }
            else if (number > 1000)
            {
                bonnus = number * 0.1;
            }
            else
            {
                bonnus = number * 0.2;
            }
            if (number % 2 == 0)
            {
                bonnus = bonnus + 1;
            }
            else if (number / 10 == 5)
            {
                bonnus = bonnus + 2;

                Console.WriteLine(bonnus);
                Console.WriteLine(bonnus + number);


            }

        }
    }
}

