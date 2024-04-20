using System;

namespace _06._Tournament_of_Christmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double daySumMoney = 0;
            double fullSum = 0;
            int winCount = 0;
            int loseCount = 0;
            int dayWinCount = 0;
            int dayLoseCount = 0;
            int numDays = int.Parse(Console.ReadLine());        
            for (int i = 0; i < numDays; i++)
            {
                while (true)
                {
                    string sport = Console.ReadLine();
                    if (sport == "Finish")
                    {
                        break;
                    }
                    string winOrLoose = Console.ReadLine();
                    if (winOrLoose == "win")
                    {
                        daySumMoney += 20;
                        winCount++;
                    }
                    else if (winOrLoose == "lose")
                    {
                        daySumMoney += 0;
                        loseCount++;
                    }
                    
                }
                if (winCount > loseCount)
                {
                    daySumMoney += daySumMoney * 0.10;
                    dayWinCount++;
                }
                else
                {
                    dayLoseCount++;
                }
                fullSum += daySumMoney;
                daySumMoney = 0;
                winCount = 0;
                loseCount = 0;
               
            }
            if (dayWinCount > dayLoseCount)
            {
                fullSum += fullSum * 0.20;
                Console.WriteLine($"You won the tournament! Total raised money: {fullSum:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {fullSum:f2}");
            }
        }
    }
}
