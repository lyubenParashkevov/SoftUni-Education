using System.Text;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string customerPatern = @"(?<customer>[A-Z][a-z]+)";
            string productPatern = @"(?<product>[A-Z][a-z]+)";
            string countPatern = @"(?<count>\d+)";
            string pricePatern = @"(?<price>\d+(\.\d+)?)";
            string junk = @"[^|$%.]";
            string patern = @$"\%{customerPatern}\%{junk}*\<{productPatern}\>{junk}*\|{countPatern}\|{junk}*?{pricePatern}\$";
            decimal sum = 0;

           

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift")
                {
                    break;
                }


                MatchCollection matches = Regex.Matches(input, patern);

                foreach (Match match in matches)
                {
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    decimal productPrice = price * count;
                    sum += productPrice;

                    Console.WriteLine($"{customer}: {product} - {productPrice:f2}");

                }

            }
            
            Console.WriteLine($"Total income: {sum:f2}");
        }
    }
}