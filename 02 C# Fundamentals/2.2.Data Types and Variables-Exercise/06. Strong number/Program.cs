using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int nCopy = n;
            int curNum = 0;
            int factorialSum = 0;

            while (nCopy != 0)
            {
                curNum = nCopy % 10;
                nCopy /= 10;

                int factorial = 1;
                for (int i = 1; i <= curNum; i++)
                {
                    factorial *= i;
                }
                factorialSum += factorial;

            }
            if (n == factorialSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            
        }
    }
}
