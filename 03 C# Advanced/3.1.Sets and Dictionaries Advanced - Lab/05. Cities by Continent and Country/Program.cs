﻿namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> countriesAndCities 
                = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!countriesAndCities.ContainsKey(continent) )
                {
                    countriesAndCities.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!countriesAndCities[continent].ContainsKey(country))
                {
                    countriesAndCities[continent].Add(country, new List<string>());
                }

                countriesAndCities[continent][country].Add(city);
            }

            foreach(var continent in countriesAndCities)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");                    
                }
            }
        }
    }
}