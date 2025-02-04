using System;

namespace _06._Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            string acterName = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int nJudges = int.Parse(Console.ReadLine());

            string nameJudge;
            double pointsFromJudge = 0;
            double recievedPoints = 0;
            
            for (int i = 0; i < nJudges; i++)
            {
                nameJudge = Console.ReadLine();
                pointsFromJudge = double.Parse(Console.ReadLine());
                double namePoints = nameJudge.Length;
                recievedPoints += namePoints * pointsFromJudge / 2;
                if (recievedPoints + points > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {acterName} got a nominee for leading role with {recievedPoints + points:f1}!");
                    break;
                }    
            }
            if (recievedPoints + points <= 1250.5)
            {
                Console.WriteLine($"Sorry, {acterName} you need {1250.5 - recievedPoints - points:f1} more!");
            }
                                





        }
    }
}
