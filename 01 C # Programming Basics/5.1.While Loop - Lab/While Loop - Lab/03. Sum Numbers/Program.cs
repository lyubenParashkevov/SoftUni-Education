using System;

namespace _03._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int num = 0;
            int sum = 0;
            while (sum < number)
            {
                num = int.Parse(Console.ReadLine());
                sum += num;


            }
            Console.WriteLine(sum);
        }

    }
}
