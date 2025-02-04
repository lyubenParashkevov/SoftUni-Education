using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numLostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int lostGamesCount = 0;
            int keyboardTrashCount = 0;
           


            double sum = 0;

            for (int i = 0; i < numLostGames; i++)
            {
                lostGamesCount++;
                if (lostGamesCount % 6 == 0)
                {
                    sum += headsetPrice + mousePrice + keyboardPrice;
                    keyboardTrashCount++;
                    if (keyboardTrashCount % 2 == 0)
                    {
                        sum += displayPrice;
                    }
                }
                else if (lostGamesCount % 2 == 0)
                {
                    sum += headsetPrice;
                }
                else if (lostGamesCount % 3 == 0)
                {
                    sum += mousePrice;
                }
               
            }
            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
