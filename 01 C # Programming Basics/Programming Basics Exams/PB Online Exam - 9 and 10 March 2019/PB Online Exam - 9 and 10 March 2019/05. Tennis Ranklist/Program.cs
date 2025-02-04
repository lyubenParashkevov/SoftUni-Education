using System;

namespace _05._Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournamentsNum = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            double winCount = 0;
            double curPoints = 0;

            for (int i = 0; i < tournamentsNum; i++)
            {
                string endingPlace = Console.ReadLine();
                if (endingPlace == "W")
                {
                    curPoints += 2000;
                    winCount++;
                }
                else if (endingPlace == "F")
                {
                    curPoints += 1200;
                }
                else if (endingPlace == "SF")
                {
                    curPoints += 720;
                }
            }
            double percent = winCount / tournamentsNum * 100;
            Console.WriteLine($"Final points: {startingPoints + curPoints}");
            Console.WriteLine($"Average points: {Math.Floor(curPoints / tournamentsNum)}");
            Console.WriteLine($"{percent:f2}%");
        }
    }
}
