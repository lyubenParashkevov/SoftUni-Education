using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string patern = @"(?<day>[0-9][0-9])(?<separator>\.|-|\/)(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})";

            Regex regex = new Regex(patern);

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;


                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");

            }


        }

    }
}