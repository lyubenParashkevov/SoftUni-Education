using System.Text.RegularExpressions;

namespace _01_02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string patern = @"(#|\|)(?<product>[A-Z a-z]+)\1(?<expiration>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,})\1";
            int caloriesSum = 0;
            int caloriesForDay = 2000;
            Regex regex = new Regex(patern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                caloriesSum += int.Parse(match.Groups["calories"].Value);
            }

            Console.WriteLine($"You have food to last you for: {caloriesSum / caloriesForDay} days!");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["product"].Value}, Best before: {match.Groups["expiration"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}