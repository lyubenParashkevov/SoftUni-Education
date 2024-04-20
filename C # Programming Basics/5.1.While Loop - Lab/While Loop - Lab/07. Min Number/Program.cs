using System;

namespace _07._Min_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNum = int.MaxValue;
            string input = String.Empty;
            int currNum = 0;

            while ((input = Console.ReadLine()) != "Stop")
            {
                currNum = int.Parse(input);
                {
                    if (currNum < minNum)
                        minNum = currNum;
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
