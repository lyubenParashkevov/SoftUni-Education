using System;

namespace _06._Favorite_Movie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int movieCounter = 0;
            int pointsSum = 0;
            string bestMovie = "";
            int maxPoints = int.MinValue;
            while (true)
            {
                string movie = Console.ReadLine();
                movieCounter++;
                pointsSum = 0;
                if (movie == "STOP")
                {
                    Console.WriteLine($"The best movie for you is {bestMovie} with {maxPoints} ASCII sum.");
                    break;
                }
                if (movieCounter == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    Console.WriteLine($"The best movie for you is {bestMovie} with {maxPoints} ASCII sum.");
                    break;
                }
              

                for (int i = 0; i < movie.Length; i++)
                {
                   char letter = movie[i];
                    pointsSum += letter;
                    if (char.IsLower(letter))
                    {
                        pointsSum -= 2 * movie.Length;
                    }
                    else if (char.IsUpper(letter))
                    {
                        pointsSum -= movie.Length;
                    }
                }
                if (pointsSum > maxPoints)
                {
                    maxPoints = pointsSum;
                    bestMovie = movie;
                }

                
            }
        }
    }
}
