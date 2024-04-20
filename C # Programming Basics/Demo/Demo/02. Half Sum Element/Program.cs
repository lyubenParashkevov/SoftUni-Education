using System;

namespace _02._Half_Sum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int sumWithOutMaxNum = 0;
            int currNum = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                currNum = int.Parse(Console.ReadLine());
                sum += currNum;
                if (currNum > maxNum)
                {
                    maxNum = currNum;
                }
                    sumWithOutMaxNum = sum - maxNum;
            }
                                
            if (sumWithOutMaxNum == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNum} ");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumWithOutMaxNum - maxNum)}");
            }










        }
    }
}
