using System;

namespace _06._Max_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.MinValue;
            string input = String.Empty;
            int currNum = 0;

            while ((input = Console.ReadLine()) != "Stop")
            {
                currNum = int.Parse(input);
                {
                    if (currNum > maxNum) 
                        maxNum = currNum;
                }
            }
            Console.WriteLine(maxNum);
        }
    }
}
