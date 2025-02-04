using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string patern = @"\+[359]{3}(?<separator> |-)[2]\k<separator>[0-9]{3}\k<separator>[0-9]{4}\b";

            Regex regex = new Regex(patern);

            MatchCollection matches = regex.Matches(input);

            Console.WriteLine(string.Join(", ", regex.Matches(input)));
        }
    }
}