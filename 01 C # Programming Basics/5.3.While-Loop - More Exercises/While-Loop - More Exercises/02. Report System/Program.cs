using System;

namespace _02._Report_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());
            string input = "";
            double cashSum = 0;
            int moneyToPay = 0;
            int cardPayCount = 0;
            int cashPayCount = 0;
            int transactionCount = 0;
            double cardSum = 0;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    return;
                }
                moneyToPay = int.Parse(input);
                transactionCount++;
                if (moneyToPay > 100 && transactionCount % 2 != 0)
                {
                    Console.WriteLine("Error in transaction!");
                    continue;
                }
                if (moneyToPay < 10 && transactionCount % 2 == 0)
                {
                    Console.WriteLine("Error in transaction!");
                    continue ;
                }


                if (transactionCount % 2 == 0)
                {
                    cardPayCount++;
                    cardSum += moneyToPay;
                    Console.WriteLine("Product sold!");
                    
                }
                else
                {
                    cashPayCount++;
                    cashSum += moneyToPay;
                    Console.WriteLine("Product sold!");
                }
                if (cashSum + cardSum >= targetSum)
                    break;
            }
            Console.WriteLine($"Average CS: {cashSum / cashPayCount:f2}");
            Console.WriteLine($"Average CC: {cardSum / cardPayCount:f2}");
        }
    }
}
