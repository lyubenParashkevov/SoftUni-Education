using System;

namespace _11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            int sum = 0;


            for (int i = multiplier; i <= 10; i++)
            {
                sum = n * i;
                if (multiplier > 10)
                {
                    Console.WriteLine($"{n} X {multiplier} = {sum}");
                    break;
                }
                Console.WriteLine($"{n} X {i} = {sum}");
            }
            if (multiplier > 10)
            {
                sum = n * multiplier;
                Console.WriteLine($"{n} X {multiplier} = {sum}");

            }
        }
    }
}
