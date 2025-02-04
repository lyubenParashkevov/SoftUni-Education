using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            double ownMoney = double.Parse(Console.ReadLine());
            int dayCount = 0;
            int SpendingDaysCount = 0;

            while (ownMoney < tripPrice)
            {
                string spendOrSave = Console.ReadLine();
                double moneyToSpendOrSave = double.Parse(Console.ReadLine());
                if (spendOrSave == "spend")
                {
                    dayCount++;
                    SpendingDaysCount++;
                    ownMoney -= moneyToSpendOrSave;
                    if (ownMoney < 0)
                    {
                        ownMoney = 0;
                    }
                }
                else if (spendOrSave == "save")
                {
                    dayCount++;
                    SpendingDaysCount = 0;
                    ownMoney += moneyToSpendOrSave;
                }
                if (SpendingDaysCount == 5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine(dayCount);
                }
                if (ownMoney >= tripPrice)
                {
                    Console.WriteLine($"You saved the money for {dayCount} days.");
                }

 

            }

        }
    }
}
