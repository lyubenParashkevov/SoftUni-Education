using System;

namespace _08._Equal_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            
            int maxSum = int.MinValue;
            int minSum = int.MaxValue;
            int equalCount = 0;
            int sum = 0;
            
            for (int i = 0; i < n; i++)
            {
               int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());

                 sum = firstNum + secondNum;
                

                if (sum < minSum)
                {
                    minSum = sum;
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
                if (minSum == maxSum)
                {
                    equalCount++;
                }


            }
            if (equalCount == n)
            {
                Console.WriteLine($"Yes, value={maxSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxSum - minSum}");
            }
        }
    }
}
