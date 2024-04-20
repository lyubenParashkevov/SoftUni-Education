using System;

namespace _06._Basketball_Tournament
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double winCount = 0;
            int gameCount = 0;
            double losesCount = 0;
            int tournamentGameCount = 0;
            while (true)
            {
                string tournament = Console.ReadLine();

                if (tournament == "End of tournaments")
                {
                    Console.WriteLine($"{winCount / gameCount * 100:f2}% matches win");
                    Console.WriteLine($"{losesCount / gameCount * 100:f2}% matches lost");
                    break;
                }
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    int desiTeamPoints = int.Parse(Console.ReadLine());
                    int oderTeamPoints = int.Parse(Console.ReadLine());
                    gameCount++;
                    tournamentGameCount++;
                    if (desiTeamPoints > oderTeamPoints)
                    {
                        winCount++;
                        Console.WriteLine($"Game {tournamentGameCount} of tournament {tournament}: win with {desiTeamPoints - oderTeamPoints} points.");
                    }
                    else if (desiTeamPoints < oderTeamPoints)
                    {
                        losesCount++;
                        Console.WriteLine($"Game {tournamentGameCount} of tournament {tournament}: lost with {oderTeamPoints - desiTeamPoints} points.");
                    }
                }
                tournamentGameCount = 0;
            }
        }
    }
}
