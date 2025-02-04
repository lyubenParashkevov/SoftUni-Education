using System.Text.RegularExpressions;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(?<day>\d{2})(?<separator>\.|-|\/)(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})";

            string input = Console.ReadLine();

            Regex regex = new Regex(patern);

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {

                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }


            
            
        }
    }
}