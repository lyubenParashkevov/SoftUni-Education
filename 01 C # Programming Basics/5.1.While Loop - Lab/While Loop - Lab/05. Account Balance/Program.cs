using System;

namespace _05._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double tottal = 0;
            string input;

            while ((input = Console.ReadLine()) != "NoMoreMoney")
            {
                 double money = double.Parse(input);
                if (money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                    Console.WriteLine($"Total: {tottal}");
                }
                else if (money >= 0 )
                {
                    Console.WriteLine($"Increase: {money:f2}");
                    tottal += money;
                }
                
            }
            Console.WriteLine($"Total: {tottal:f2}");

        }
    }
}