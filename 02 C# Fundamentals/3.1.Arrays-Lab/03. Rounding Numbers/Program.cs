using System;

namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            double[] curNum = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {

                curNum[i] = double.Parse(input[i]);
                Console.WriteLine($"{curNum[i]} => {(int)Math.Round(curNum[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
