using System;

namespace _08._Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int nTournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int allPoints = 0;
            int countW = 0;         //	W - ако е победител получава 2000 точки       
            int countF = 0;         //	F - ако е финалист получава 1200 точки
            int countSF = 0;        // SF - ако е полуфиналист получава 720 точки            
            double averagePoints = 0;
            for (int i = 0; i < nTournaments; i++)
            {
                string range = Console.ReadLine();
                if (range == "W")
                {
                    allPoints += 2000;
                    countW++;
                }
                else if (range == "F")
                {
                    allPoints += 1200;
                    countF++;
                }
                else if (range == "SF")
                {
                    allPoints += 720;
                    countSF++;
                }
                averagePoints = allPoints / nTournaments;
            }
            Console.WriteLine($"Final points: {allPoints + startingPoints}");
            //Отпечатват се три реда в следния формат:// 1 . "Final points: {брой точки след изиграните турнири}"
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            // 2  "Average points: {средно колко точки печели за турнир}"Math.Floor
            Console.WriteLine($"{(double)countW / nTournaments * 100:f2}%");
            // 3 ."{процент спечелени турнири}%" :f2

            




        }
    }
}
