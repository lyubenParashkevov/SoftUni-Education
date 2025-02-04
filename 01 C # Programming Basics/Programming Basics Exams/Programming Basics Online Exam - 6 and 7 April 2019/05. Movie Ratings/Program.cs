using System;

namespace _05._Movie_Ratings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lowestRating = double.MaxValue;
            double highestRating = double.MinValue;
            double averageRating = 0;
            double ratingSum = 0;
            string bestMovie = "";
            string worsMovie = "";
            int numMovies = int.Parse(Console.ReadLine());
            for (int i = 0; i < numMovies; i++)
            {
                string movieName = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                if (rating > highestRating)
                {
                    bestMovie = movieName;
                    highestRating = rating;
                    ratingSum+=rating;
                }
                else if (rating < lowestRating)
                {
                    worsMovie = movieName;
                    lowestRating = rating;
                    ratingSum += rating;
                }
                else
                {
                    ratingSum += rating;
                }
            }
            Console.WriteLine($"{bestMovie} is with highest rating: {highestRating:f1}");
            Console.WriteLine($"{worsMovie} is with lowest rating: {lowestRating:f1}");
            Console.WriteLine($"Average rating: {ratingSum / numMovies:f1}");
        }
    }
}
