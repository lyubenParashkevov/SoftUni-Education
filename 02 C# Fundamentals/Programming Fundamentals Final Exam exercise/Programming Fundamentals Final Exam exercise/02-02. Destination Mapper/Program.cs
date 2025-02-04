using System.Text.RegularExpressions;

namespace _02_02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string input = Console.ReadLine();
            string patern = @"(\/|=)(?<destination>[A-Z][A-za-z]{2,})\1";
            int points = 0;
            Regex regex = new Regex(patern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                points += match.Groups["destination"].Value.Length;
                list.Add(match.Groups["destination"].Value);
            }
            Console.WriteLine($"Destinations: {string.Join(", ",list)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}