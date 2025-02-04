using System;

namespace _04._Cat_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int catNum = int.Parse(Console.ReadLine());
            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            double foodWeight = 0;
            double foodSum = 0;
            double foodPrice = 0;
            for (int i = 0; i < catNum; i++)
            {

            
                foodWeight = double.Parse(Console.ReadLine());
                if (foodWeight < 200)
                {
                    group1++;
                    foodSum+=foodWeight;
                }
                else if (foodWeight < 300)
                {
                    group2++;
                    foodSum += foodWeight;
                }
                else if (foodWeight <= 400)
                {
                    group3 ++;
                    foodSum += foodWeight;

                }
                foodPrice = foodSum / 1000 * 12.45;
            }
            
            Console.WriteLine($"Group 1: {group1} cats.");
            Console.WriteLine($"Group 2: {group2} cats.");
            Console.WriteLine($"Group 3: {group3} cats.");
            Console.WriteLine($"Price for food per day: {foodPrice:f2} lv.");
        }
    }
}
