using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string patern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            Regex validNames = new Regex(patern);

            MatchCollection matches = validNames.Matches(input);

            Console.WriteLine(string.Join(' ', validNames.Matches(input)));


        }
    }
}