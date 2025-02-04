using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<string> products = new List<string>();
            
            decimal sum = 0;
            while (true)
            {
                string input = Console.ReadLine();


                if (input == "Purchase")
                {
                    Console.WriteLine("Bought furniture:");
                    break;
                }

                string patern = @">>(?<product>[A-Za-z]+)<<(?<price>[0-9]+\.?[0-9]+)!(?<quantity>[0-9]+)";

                MatchCollection matches = Regex.Matches(input, patern);

                foreach (Match match in matches)
                {
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    sum += price * quantity;

                    products.Add(match.Groups["product"].Value);
                }
            }
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}