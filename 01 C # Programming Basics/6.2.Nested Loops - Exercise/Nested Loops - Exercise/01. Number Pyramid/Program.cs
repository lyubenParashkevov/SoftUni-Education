using System;

namespace _01._Number_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currNum = 1;
            bool isBigger = false;

            for (int row = 1; row <= n; row++)
            {
                for (int cols = 1; cols <= row; cols++)
                {
                    if (currNum > n)
                    {

                        isBigger = true;
                        break;
                    }
                   Console.Write($"{currNum} ");
                    currNum++;
                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
