using System;

namespace _09._Left_and_Right_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = n1;
            int sum1 = 0;
            int sum2 = 0;
            int sum = sum1 + sum2;
            for (int i = 0; i < n1; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());
                sum1 += currNumber;
            }
            for (int i = 0; i < n2; i++)
            {
                int currNumber2 = int.Parse(Console.ReadLine());
                sum2 += currNumber2;
            }
            if (sum1 == sum2)
            {
                sum = sum1; 
                Console.WriteLine($" Yes, sum = {sum}");
            }
            if (sum1 != sum2)
            {
                sum = sum1 - sum2;
                Console.WriteLine($" No, diff = {Math.Abs(sum)}");
            }

                

        }
    }
}
