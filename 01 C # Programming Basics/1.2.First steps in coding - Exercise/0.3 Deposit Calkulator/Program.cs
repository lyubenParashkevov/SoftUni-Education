using System;

namespace _0._3_Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine()) / 100;
            double sum = depositSum + month * ((depositSum * percent) / 12);
            Console.WriteLine(sum);
        }
    }
}
 